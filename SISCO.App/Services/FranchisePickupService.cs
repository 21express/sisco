using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SISCO.App.Services
{
    public class FranchisePickupService
    {
        public void Save(ref FranchisePickupModel pickup, List<FranchisePickupDetailModel> pickupDetail, List<ShipmentModel> voidedShipment)
        {
            var repo = new FranchisePickupRepository();

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    pickup.Code = repo.GenerateCode_2(pickup.DateProcess);
                    repo.Save<FranchisePickupModel>(pickup);

                    var detailRepo = new FranchisePickupDetailRepository(repo.Entities);
                    var shipmentRepo = new ShipmentRepository(repo.Entities);

                    foreach (var obj in pickupDetail)
                    {
                        if (obj.StateChange == EnumStateChange.Insert)
                        {
                            if (detailRepo.GetSingle<FranchisePickupDetailModel>(WhereTerm.Default(obj.ShipmentId, "shipment_id")) != null) throw new Exception(string.Format("Shipment {0} is already picked up.", obj.ShipmentCode));

                            obj.Rowstatus = true;
                            obj.Rowversion = DateTime.Now;
                            obj.FranchisePickupId = pickup.Id;
                            obj.CreatedPc = Environment.MachineName;
                            obj.Createdby = pickup.Createdby;
                            obj.Createddate = DateTime.Now;

                            detailRepo.Save<FranchisePickupDetailModel>(obj);

                            var shipment = shipmentRepo.GetSingle<ShipmentModel>(WhereTerm.Default(obj.ShipmentId, "id"));
                            if (shipment != null)
                            {
                                shipment.PODStatus = (int)EnumPodStatus.PickedUp;
                                shipment.ModifiedPc = Environment.MachineName;
                                shipment.Modifiedby = pickup.Createdby;
                                shipment.Modifieddate = DateTime.Now;

                                shipmentRepo.Update<ShipmentModel>(shipment);
                            }
                        }
                    }

                    foreach (var voided in voidedShipment)
                    {
                        var obj = new FranchisePickupDetailModel();

                        obj.Rowstatus = true;
                        obj.Rowversion = DateTime.Now;
                        obj.FranchisePickupId = pickup.Id;
                        obj.ShipmentId = voided.Id;
                        obj.CreatedPc = Environment.MachineName;
                        obj.Createdby = pickup.Createdby;
                        obj.Createddate = DateTime.Now;

                        detailRepo.Save<FranchisePickupDetailModel>(obj);

                        voided.PODStatus = (int)EnumPodStatus.PickedUp;
                        voided.ModifiedPc = Environment.MachineName;
                        voided.Modifiedby = pickup.Createdby;
                        voided.Modifieddate = DateTime.Now;

                        shipmentRepo.Update<ShipmentModel>(voided);
                    }

                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    repo.Entities.ExecuteStoreCommand(string.Format("UPDATE franchise_pickup SET rowstatus = 0, modifiedby = 'CANCELLED' WHERE id = {0}", pickup.Id));
                    repo.Entities.ExecuteStoreCommand(string.Format("UPDATE franchise_pickup_detail SET rowstatus = 0, modifiedby = 'CANCELLED' WHERE franchise_pickup_id = {0}", pickup.Id));

                    throw ex;
                }
            }
        }
    }
}
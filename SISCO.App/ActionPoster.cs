using System;
using System.Collections.Generic;
using System.Transactions;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;

namespace SISCO.App
{
    public enum Transaction
    {
        PickupOrder,
        Sales,
        Payment,
        Manifest,
        OutboundDarat,
        OutboundUdara,
        DeliveryOrder,
        Inbound,
    }

    public enum Department
    {
        Accounting = 1,
        AdmInbound = 2,
        AdmOutbound = 3,
        Audit = 4,
        Bandara = 5,
        Billing = 6,
        CityCourier = 7,
        Collector = 8,
        Counter = 9,
        Cso = 10,
        DataEntry = 11,
        Dm = 12,
        Driver = 13,
        DriverAsist = 14,
        GeneralAdviser = 15,
        Hrd = 16,
        It = 17,
        KepalaCabang = 18,
        KepalaKoordinator = 19,
        Koordinator = 20,
        Kurir = 21,
        ManagerNiaga = 22,
        Manifest = 23,
        Marketing = 24,
        Mekanik = 25,
        Ob = 26,
        OperasionalMalam = 27,
        Smu = 28,
        SubAgent = 29
    }

    public class ActionPoster
    {
        public static void Post(int userLoginId, string userLogin, Transaction transaction, IBaseModel model, params KeyValuePair<string, object>[] extraParameters)
        {
            Transaction nextTransaction;

            using (var scope = new TransactionScope())
            {
                switch (transaction)
                {
                    case Transaction.Sales:
                        var shipment = (ShipmentModel)model;

                        if (shipment.ServiceTypeId == 1)
                        {
                            nextTransaction = Transaction.DeliveryOrder;
                        }
                        else
                        {
                            nextTransaction = Transaction.Manifest;
                        }

                        PostNotification(userLoginId, userLogin, new InboxModel
                        {
                            BranchId = (int)shipment.DestBranchId,
                            DepartmentId = (int)Department.Manifest,
                            Description = string.Format("{0}-{1}", shipment.BranchName, shipment.DestBranchName),
                            RefId = shipment.Id,
                            RefNumber = shipment.Code,
                            TransactionType = nextTransaction.ToString()
                        });
                        PostJournal();
                        break;

                    case Transaction.Manifest:
                        var manifest = (ManifestModel)model;

                        nextTransaction = Transaction.OutboundDarat;

                        PostNotification(userLoginId, userLogin, new InboxModel
                        {
                            BranchId = manifest.DestBranchId,
                            DepartmentId = (int)Department.AdmOutbound,
                            Description = string.Format("{0}-{1}", manifest.BranchName, manifest.DestBranch),
                            RefId = manifest.Id,
                            RefNumber = manifest.Code,
                            TransactionType = nextTransaction.ToString()
                        });
                        PostJournal();
                        break;

                    case Transaction.OutboundDarat:
                        var waybill = (WaybillModel)model;

                        nextTransaction = Transaction.Inbound;

                        PostNotification(userLoginId, userLogin, new InboxModel
                        {
                            BranchId = waybill.DestBranchId,
                            DepartmentId = (int)Department.AdmInbound,
                            Description = string.Format(""),
                            RefId = waybill.Id,
                            RefNumber = waybill.Code,
                            TransactionType = nextTransaction.ToString()
                        });
                        PostJournal();
                        break;

                    case Transaction.OutboundUdara:
                        var airwaybill = (AirwaybillModel)model;

                        nextTransaction = Transaction.Inbound;

                        PostNotification(userLoginId, userLogin, new InboxModel
                        {
                            BranchId = airwaybill.DestBranchId,
                            DepartmentId = (int)Department.AdmInbound,
                            Description = string.Format(""),
                            RefId = airwaybill.Id,
                            RefNumber = airwaybill.Code,
                            TransactionType = nextTransaction.ToString()
                        });
                        PostJournal();
                        break;

                    case Transaction.Inbound:
                        var inbound = (InboundModel)model;

                        nextTransaction = Transaction.DeliveryOrder;

                        PostNotification(userLoginId, userLogin, new InboxModel
                        {
                            BranchId = inbound.BranchId,
                            DepartmentId = (int)Department.Dm,
                            Description = string.Format(""),
                            RefId = inbound.Id,
                            RefNumber = inbound.Code,
                            TransactionType = nextTransaction.ToString()
                        });
                        PostJournal();
                        break;

                    case Transaction.PickupOrder:
                        PostJournal();
                        PostNotification(userLoginId, userLogin, new InboxModel());
                        break;

                    default:
                        throw new Exception("Transaction not recognized");
                }

                scope.Complete();
            }
        }

        private static void PostNotification(int userLoginId, string userLogin, InboxModel model)
        {
            model.DateAssigned = DateTime.Now;
            model.IsOpen = true;

            model.Rowstatus = true;
            model.Rowversion = DateTime.Now;
            model.Createddate = DateTime.Now;
            model.Createdby = userLogin;

            using (var dm = new InboxDataManager())
            {
                dm.Save<InboxModel>(model);
            }
        }

        private static void PostJournal()
        {
            //throw new NotImplementedException();
        }

        public static void View(Transaction transaction, int? refId = null, string refNumber = null)
        {
            var parameters = new List<IListParameter>();

            parameters.Add(WhereTerm.Default(transaction.ToString(), "transaction_type"));
            parameters.Add(WhereTerm.Default(true, "row_status"));

            if (refId != null)
            {
                parameters.Add(WhereTerm.Default((int) refId, "ref_id"));
            }
            else if (refNumber != null)
            {
                parameters.Add(WhereTerm.Default(refNumber, "ref_number"));
            }
            else
            {
                throw new Exception("Either RefID or RefNumber parameter must be supplied");
            }

            using (var dm = new InboxDataManager())
            {
                var row = dm.GetFirst<InboxModel>(parameters.ToArray());

                row.DateViewed = DateTime.Now;

                //if (false)
                //{
                //    row.IsOpen = false;
                //    row.DateCompleted = DateTime.Now;
                //}

                dm.Update<InboxModel>(row);
            }
        }
    }
}

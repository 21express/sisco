using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class ShipmentDataManager : BaseDataManager
    {
        public ShipmentDataManager()
        {
            Repository = new ShipmentRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }

        public int GetCount(params IListParameter[] parameter)
        {
            return ((ShipmentRepository)Repository).GetCount(parameter);
        }

        public override void Save<T>(IBaseModel businessModel)
        {
            if (((ShipmentModel)businessModel).AutoNumber && string.IsNullOrEmpty(((ShipmentModel)businessModel).Code))
            {
                ((ShipmentModel)businessModel).Code = GenerateCode(businessModel as ShipmentModel);
            }

            Repository.Save(businessModel);

            ActionPoster.Post(0, businessModel.Createdby, Transaction.Sales, businessModel);
        }

        public override void Update<T>(IBaseModel businessModel)
        {
            Repository.Update(businessModel);
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            Repository.DeActive(id, userName, deleteDate);
        }

        public IEnumerable<SISCO.Models.ShipmentRowModel> ShipmentList(IListParameter[] param)
        {
            return new ShipmentRepository().GetGrid<SISCO.Models.ShipmentRowModel>(param);
        }

        public IEnumerable<ShipmentModel> CollectInList(IListParameter[] param)
        {
            return new ShipmentRepository().CollectInList(param);
        }

        public IEnumerable<ShipmentModel> CollectOutList(IListParameter[] param)
        {
            return new ShipmentRepository().CollectOutList(param);
        }

        public IEnumerable<SISCO.Models.ShipmentModel.ShipmentReportRow> ShipmentListExport(IListParameter[] param)
        {
            return new ShipmentRepository().ShipmentExportExcel(param);
        }

        public IEnumerable<ShipmentModel> ShipmentExportExcel(DateTime? fromDate, DateTime? toDate, DateTime? invoiceDateFrom,
            DateTime? invoiceDateTo, string paymentMethod, string invoiceNumber, string receiptNumber)
        {
            return new ShipmentRepository().ShipmentExportExcel(fromDate, toDate, invoiceDateFrom, invoiceDateTo,
                paymentMethod, invoiceNumber, receiptNumber);
        }

        public string GenerateCode(ShipmentModel model)
        {
            return ((ShipmentRepository)Repository).GenerateCode(model);
        }

        public string GenerateFranchisePODCode(ShipmentModel model)
        {
            return ((ShipmentRepository)Repository).GenerateFranchisePODCode(model);
        }

        public string GenerateFranchisePODCode_API(ShipmentModel model)
        {
            return ((ShipmentRepository)Repository).GenerateFranchisePODCode_API(model);
        }

        public string GenerateECOPODCode_API(int branchId)
        {
            return new ShipmentRepository().GenerateECOPODCode_API(branchId);
        }

        public string GenerateCorporatePODCode(ShipmentModel model)
        {
            return ((ShipmentRepository)Repository).GenerateCorporatePODCode(model);
        }

        public IEnumerable<T> GetExclude<T>(IListParameter[] listParameter, int[] filterExcludeShipmentIds)
        {
            return ((ShipmentRepository)Repository).GetExclude<T>(listParameter, filterExcludeShipmentIds);
        }

        public void CancelInvoice(List<int> canceledShipmentIds)
        {
            ((ShipmentRepository)Repository).CancelInvoice(canceledShipmentIds);
        }

        public IEnumerable<ShipmentModel> GetInbound(params IListParameter[] listParameter)
        {
            return new ShipmentRepository().GetInbound(listParameter);
        }

        public IEnumerable<string> GetByCodes(IEnumerable<string> codes)
        {
            return ((ShipmentRepository)Repository).GetByCodes(codes);
        }

        public IEnumerable<ShipmentModel> GetShipmentByCodes(IEnumerable<string> codes)
        {
            return ((ShipmentRepository)Repository).GetShipmentByCodes(codes);
        }

        public IEnumerable<SISCO.Models.ShipmentRowModel> GetInvoiceShipment(IEnumerable<string> codes)
        {
            return ((ShipmentRepository)Repository).GetInvoiceShipment(codes);
        }

        public IEnumerable<ShipmentModel> IncomingList(IListParameter[] listParameter, IListParameter[] listParameter2)
        {
            return ((ShipmentRepository)Repository).IncomingList(listParameter, listParameter2);
        }

        public bool CheckPrefixBranchShipment(int branchId, string code, bool isCounterCash = false)
        {
            code = code.Substring(0, 4);
            var param = new IListParameter[]
                {
                    WhereTerm.Default(branchId, "id", EnumSqlOperator.Equals)
                };

            var branch = new BranchDataManager().GetFirst<BranchModel>(param);
            if (branch == null) return false;

            if (isCounterCash)
            {
                if (string.IsNullOrEmpty(branch.PrefixCode) && string.IsNullOrEmpty(branch.PrefixCode1) && string.IsNullOrEmpty(branch.PrefixCode2)) return true;
                return (branch.PrefixCode == code || branch.PrefixCode1 == code || branch.PrefixCode2 == code);
            }

            if (string.IsNullOrEmpty(branch.PrefixCode1) && string.IsNullOrEmpty(branch.PrefixCode2)) return true;
            return (branch.PrefixCode1 == code || branch.PrefixCode2 == code);
        }

        public ShipmentModel GetTariff(ShipmentModel model, int currentCountryId)
        {
            if (model.DestCityId > 0)
            {
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals));
                var country =
                    new CountryDataManager().GetFirst<CountryModel>(WhereTerm.Default(city.CountryId, "id",
                        EnumSqlOperator.Equals));

                model.PricingPlanId = country.PricingPlanId;
                model.PackingFee = model.PackingFee > 0 ? model.PackingFee : 0;
                if (country.Id == currentCountryId)
                {
                    CustomerTariffModel cusTariff;
                    if (model.CustomerId != null)
                    {
                        cusTariff = new CustomerTariffDataManager().GetTariff(model.CityId, model.DestCityId,
                            model.ServiceTypeId, model.PackageTypeId, (int) model.CustomerId, model.TtlChargeableWeight);
                    }
                    else cusTariff = null;

                    if (cusTariff == null)
                    {
                        var tarif = new TariffDataManager().GetTariff(model.CityId, model.DestCityId,
                            model.ServiceTypeId, model.PackageTypeId, model.TtlChargeableWeight);

                        if (tarif != null)
                        {
                            model.NeedRa = tarif.Ra??false;
                            model.Tariff = tarif.Tariff;
                            model.HandlingFee = tarif.HandlingFee;
                            model.HandlingFeeTotal = tarif.HandlingFee;

                            model.TariffTotal = ((tarif.Tariff*model.TtlChargeableWeight) + model.HandlingFeeTotal);
                            model.TariffNet = (model.TariffTotal - (model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100)));
                            model.Total = model.TariffNet + model.PackingFee;

                            // ReSharper disable once PossibleInvalidOperationException
                            var cur =
                                new CurrencyDataManager().GetFirst<CurrencyModel>(
                                    WhereTerm.Default((int)tarif.CurrencyId, "id", EnumSqlOperator.Equals));
                            model.CurrencyId = tarif.CurrencyId;
                            model.Currency = cur.Name;
                            model.CurrencyRate = cur.Rate;
                        }
                    }
                    else
                    {
                        model.NeedRa = cusTariff.Ra??false;
                        model.Tariff = cusTariff.Tariff;
                        model.HandlingFee = cusTariff.HandlingFee;
                        model.HandlingFeeTotal = cusTariff.HandlingFee;

                        if (model.TtlChargeableWeight < cusTariff.MinWeight) model.TtlChargeableWeight = cusTariff.MinWeight;

                        if (cusTariff.Tariff > 0)
                        {
                            model.TariffTotal = ((cusTariff.Tariff * model.TtlChargeableWeight) + model.HandlingFeeTotal);
                            model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) /100);
                            model.TariffNet = model.TariffTotal - model.DiscountTotal;
                        }

                        if (cusTariff.FixedTariff > 0)
                        {
                            model.TariffTotal = (decimal)cusTariff.FixedTariff + model.HandlingFeeTotal;
                            model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100);
                            model.TariffNet = model.TariffTotal - model.DiscountTotal;
                        }

                        if (cusTariff.NextTariff > 0)
                        {
                            decimal diff = 0;
                            if (cusTariff.ToWeight > 0)
                            {
                                diff = model.TtlChargeableWeight - (decimal)cusTariff.ToWeight;
                                if (cusTariff.FromWeight <= model.TtlChargeableWeight && cusTariff.ToWeight >= model.TtlChargeableWeight)
                                {
                                    if (cusTariff.Tariff > 0)
                                    {
                                        model.TariffTotal = (cusTariff.Tariff * model.TtlChargeableWeight) + model.HandlingFeeTotal;
                                        model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100);
                                        model.TariffNet = model.TariffTotal - model.DiscountTotal;
                                    }

                                    if (cusTariff.FixedTariff > 0)
                                    {
                                        model.TariffTotal = (decimal)cusTariff.FixedTariff + model.HandlingFeeTotal;
                                        model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100);
                                        model.TariffNet = model.TariffTotal - model.DiscountTotal;
                                    }
                                } else if (model.TtlChargeableWeight > cusTariff.ToWeight)
                                {
                                    if (cusTariff.Tariff > 0)
                                    {
                                        model.TariffTotal = (cusTariff.Tariff * model.TtlChargeableWeight) + model.HandlingFeeTotal;
                                        decimal diffTariff = (decimal)cusTariff.NextTariff * diff;
                                        model.TariffTotal += diffTariff;
                                        model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100);
                                        model.TariffNet = model.TariffTotal - model.DiscountTotal;
                                    }

                                    if (cusTariff.FixedTariff > 0)
                                    {
                                        model.TariffTotal = (decimal)cusTariff.FixedTariff + model.HandlingFeeTotal;
                                        decimal diffTariff = (decimal)cusTariff.NextTariff * diff;
                                        model.TariffTotal += diffTariff;
                                        model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100);
                                        model.TariffNet = model.TariffTotal - model.DiscountTotal;
                                    }
                                }
                            }
                        }

                        model.Total = model.TariffNet + model.PackingFee;

                        // ReSharper disable once PossibleInvalidOperationException
                        var cur =
                            new CurrencyDataManager().GetFirst<CurrencyModel>(
                                WhereTerm.Default((int)cusTariff.CurrencyId, "id", EnumSqlOperator.Equals));
                        model.CurrencyId = cusTariff.CurrencyId;
                        model.Currency = cur.Name;
                        model.CurrencyRate = cur.Rate;
                    }
                }
                else
                {
                    if (country.PricingPlanId != null)
                    {
                        var international = new TariffInternationalDataManager().GetTariff((int) country.PricingPlanId,
                            model.PackageTypeId, model.TtlChargeableWeight);

                        if (international != null)
                        {
                            var cur =
                                new CurrencyDataManager().GetFirst<CurrencyModel>(
                                    WhereTerm.Default(international.CurrencyId, "id", EnumSqlOperator.Equals));

                            model.Tariff = international.Tariff;
                            model.HandlingFee = international.HandlingFee??0;
                            model.HandlingFeeTotal = international.HandlingFee??0;

                            model.TariffTotal = international.Tariff + model.HandlingFeeTotal;
                            model.DiscountTotal = model.TariffTotal * ((model.DiscountPercent + model.DiscountFixed) / 100);
                            model.TariffNet = model.TariffTotal - model.DiscountTotal;
                            model.Total = ((model.TariffNet + model.PackingFee) * cur.Rate);

                            model.CurrencyId = international.CurrencyId;
                            model.Currency = cur.Name;
                            model.CurrencyRate = cur.Rate;
                        }
                    }
                }
            }

            model = GetDeliveryFee(model);

            return model;
        }

        public ShipmentModel GetDeliveryFee(ShipmentModel model)
        {
            var deliveryfee = new DeliveryTariffDataManager().GetByPackageTypeAndWeight(model.PackageTypeId, model.DestCityId, model.TtlChargeableWeight);

            if (deliveryfee != null)
            {
                model.DeliveryFee = deliveryfee.Tariff;
                model.DeliveryFeeTotal = model.TtlChargeableWeight * deliveryfee.Tariff;

                if (model.TtlChargeableWeight < deliveryfee.MinWeight)
                {
                    model.DeliveryFeeTotal = deliveryfee.MinWeight * deliveryfee.Tariff;
                }
            }

            return model;
        }

        public IEnumerable<T> GetCreditCollectOnly<T>(int branchId, Paging paging, out int count, params IListParameter[] listParameter)
        {
            return ((ShipmentRepository)Repository).GetCreditCollectOnly<T>(branchId, paging, out count, listParameter);
        }

        public IEnumerable<T> GetGetCreditCollectOnlyExclude<T>(int customerId, IListParameter[] listParameter, int[] FilterExcludeShipmentIds)
        {
            return ((ShipmentRepository)Repository).GetExcludeCreditCollectOnly<T>(customerId, listParameter, FilterExcludeShipmentIds);
        }

        public TrackingStatusModel GetFinalTrackingStatusOfShipment(int shipmentId)
        {
            return ((ShipmentRepository)Repository).GetFinalTrackingStatusOfShipment(shipmentId);
        }

        public ShipmentStatusModel GetFinalShipmentStatusOfShipment(int shipmentId)
        {
            return ((ShipmentRepository)Repository).GetFinalShipmentStatusOfShipment(shipmentId);
        }

        public ShipmentStatusModel GetFinalStatusOfShipmentOutgoingPOD(int shipmentId)
        {
            return ((ShipmentRepository)Repository).GetFinalStatusOfShipmentOutgoingPOD(shipmentId);
        }

        public IEnumerable<ShipmentModel> GetByCustomerOrCustomerCollect(int? customerId, Paging paging, out int count, IListParameter[] parameters)
        {
            return ((ShipmentRepository)Repository).GetByCustomerOrCustomerCollect(customerId, paging, out count, parameters);
        }

        public List<ShipmentRowModel> ShipmentDeliveryList(string where)
        {
            return new ShipmentRepository().ShipmentDeliveryList(where);
        }

        public List<ShipmentRowModel> UnreceivedList(string where)
        {
            return new ShipmentRepository().UnreceivedList(where);
        }

        public List<ShipmentModel> PaymentShipmentJoinCommission(int branchId, int paymentId)
        {
            return new ShipmentRepository().PaymentShipmentJoinCommission(branchId, paymentId);
        }

        public List<string> CheckPodNumber(string[] pods)
        {
            return new ShipmentRepository().CheckPodNumber(pods);
        }

        public ShipmentModel.ShipmentReportRow GetShipmentDetail(string code)
        {
            return new ShipmentRepository().GetShipmentDetail(code);
        }

        public IEnumerable<T> GetBooking<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            return new ShipmentRepository().GetBooking<T>(paging, out totalCount, parameter);
        }

        public List<ShipmentModel.ShipmentPaymentReport> GetCashList(DateTime fromDate, DateTime toDate, int branchId)
        {
            return new ShipmentRepository().GetCashList(fromDate, toDate, branchId);
        }
    }
}
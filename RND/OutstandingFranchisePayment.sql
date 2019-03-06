SELECT
	s.id, s.`code`, s.date_process, s.total, f.branch_id, b.`name`, f.`name`,
    IF(fi.id IS NULL, 0, 1) paid, fi.`code` payment_code, fi.date_process payment_date,
    IF(f.branch_id = 24, 1, IF(ft.id IS NULL, 0, 1)) transfer, ft.`code` transfer_code, ft.date_process transfer_date,
    IF(f.branch_id = 24, 1, IF(ft.confirm_admin = 1, 1, 0)) verify, fv.`code` verify_code, fv.date_process verify_date
FROM shipment s
INNER JOIN franchise f ON s.franchise_id = f.id
LEFT JOIN franchise_payment_in_detail fp ON s.id = fp.invoice_id
LEFT JOIN franchise_payment_in fi ON fp.franchise_payment_in_id = fi.id
LEFT JOIN franchise_fund_transfer_detail ff ON fp.invoice_id = ff.invoice_id
LEFT JOIN franchise_fund_transfer ft ON ff.franchise_fund_transfer_id = ft.id
LEFT JOIN franchise_fund_transfer_verification_detail fvd ON ft.id = fvd.invoice_id
LEFT JOIN franchise_fund_transfer_verification fv ON fvd.franchise_fund_transfer_verification_id = fv.id
INNER JOIN branch b ON f.branch_id = b.id
WHERE s.rowstatus = 1 AND s.voided = 0
HAVING paid = 0 OR transfer = 0 OR verify = 0
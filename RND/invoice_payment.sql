SELECT
	s.vdate `date`,
    s.code,
    s.ref_number,
    b.name branch_name,
    s.company_name,
    s.company_invoiced_to invoiced_to,
    s.total total_invoice,
    pay.`date` payment_date, 
    pay.payment
FROM sales_invoice s
LEFT JOIN branch b ON b.id = s.branch_id
LEFT JOIN (
	SELECT 
		pd.invoice_id,
		SUM(pd.payment) payment,
		MAX(p.date_process) `date`
	FROM payment_in_detail pd
	INNER JOIN payment_in p ON p.id = pd.payment_in_id AND p.rowstatus = 1
	WHERE pd.rowstatus = 1
	GROUP BY pd.invoice_id
) pay ON pay.invoice_id = s.id
WHERE s.rowstatus = 1 AND s.cancelled = 0 AND s.vdate >= '2014-01-01 00:00:00' AND s.vdate <= '2014-12-31 23:59:59'
limit 100000;
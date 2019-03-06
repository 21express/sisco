-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `PrefixCodeGenerator`(tablename VARCHAR(50), branch_id INT, tgl INT, bulan INT, tahun INT)
BEGIN
	START TRANSACTION;
		SET @last_code = 1;
        SET @prefix = '';
        
        SELECT prefix_code.prefix INTO @prefix
        FROM prefix_code
        WHERE prefix_code.rowstatus = 1 AND prefix_code.`table` = tablename
        LIMIT 1;

		SELECT prefix_code.urut + 1 INTO @last_code
		FROM prefix_code
		WHERE prefix_code.`table` = tablename
			AND prefix_code.rowstatus = 1 AND prefix_code.tgl = tgl AND prefix_code.bulan = bulan AND prefix_code.tahun = tahun
			AND prefix_code.branch_id = branch_id
        FOR UPDATE;
		
        INSERT INTO prefix_code (rowstatus, rowversion, branch_id, prefix, `table`, tgl, bulan, tahun, urut, createddate, createdby)
        SELECT 1, CURRENT_TIMESTAMP(), branch_id, @prefix, tablename, tgl, bulan, tahun, 0, CURRENT_TIMESTAMP(), 'SP' FROM DUAL WHERE NOT EXISTS(
			SELECT 1 FROM prefix_code
            WHERE prefix_code.`table` = tablename
				AND prefix_code.rowstatus = 1 AND prefix_code.tgl = tgl AND prefix_code.bulan = bulan AND prefix_code.tahun = tahun
				AND prefix_code.branch_id = branch_id
        );
        
        UPDATE prefix_code SET urut = @last_code, modifieddate = CURRENT_TIMESTAMP(), modifiedby = 'SP' WHERE prefix_code.`table` = tablename
			AND prefix_code.rowstatus = 1 AND prefix_code.tgl = tgl AND prefix_code.bulan = bulan AND prefix_code.tahun = tahun
			AND prefix_code.branch_id = branch_id;
	COMMIT;

	SELECT @last_code AS `index`, @prefix AS 'prefix';
END
DELIMITER $$
CREATE PROCEDURE `GenerateCode`(entity VARCHAR(200),
  pattern VARCHAR(200))
BEGIN
	START TRANSACTION;

	SET @last_code = 1;
	SET @mask = '#';
	SET @length = LENGTH(pattern);
	SET @left_pos = INSTR(pattern, @mask);
	SET @right_pos = INSTR(REVERSE(pattern), @mask);

	SELECT code_journal.last_code + 1 INTO @last_code
	FROM code_journal
	WHERE code_journal.entity = entity
	AND code_journal.pattern = pattern
	LIMIT 1
	FOR UPDATE;

	INSERT INTO code_journal (entity, pattern, last_code, first_insert)
	VALUES (entity, pattern, @last_code, CURRENT_TIMESTAMP())
	ON DUPLICATE KEY UPDATE last_code = @last_code, last_update = CURRENT_TIMESTAMP();

	COMMIT;

	SET @generated_code = CONCAT(LEFT(pattern, @left_pos - 1), LPAD(@last_code, @length - @left_pos - @right_pos + 2, '0'), RIGHT(pattern, @right_pos - 1));

	SELECT @generated_code AS GeneratedCode;
END$$
DELIMITER ;
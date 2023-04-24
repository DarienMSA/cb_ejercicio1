USE RulesDB;

CREATE TABLE cbc_regla_inconsistencia(
	ReglaId int identity primary key,
	TipoRegla char(1),
	Regla varchar(150)
)

INSERT INTO cbc_regla_inconsistencia VALUES ('I', 'Regla1');
INSERT INTO cbc_regla_inconsistencia VALUES ('I', 'Regla2');
INSERT INTO cbc_regla_inconsistencia VALUES ('I', 'Regla3');

SELECT * FROM cbc_regla_inconsistencia;

CREATE PROCEDURE bp_reglas_obtener
as
begin
	SELECT * FROM cbc_regla_inconsistencia;
end

EXEC bp_reglas_obtener;
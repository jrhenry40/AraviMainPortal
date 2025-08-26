using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // --- PROCEDIMIENTO PARA CREAR ÍNDICES ---
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[pro_createindex]
			AS
			BEGIN
				SET NOCOUNT ON;
				PRINT 'Verificando y creando índices...';

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISUcsAmms_requisition' AND object_id = OBJECT_ID('dbo.SISUcsAmms'))
				BEGIN
					CREATE INDEX IX_SISUcsAmms_requisition ON dbo.SISUcsAmms (requisition_SISUcsAmms);
					PRINT 'Índice IX_SISUcsAmms_requisition creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISUcsAmms_assetid' AND object_id = OBJECT_ID('dbo.SISUcsAmms'))
				BEGIN
					CREATE INDEX IX_SISUcsAmms_assetid ON dbo.SISUcsAmms (assetid_SISUcsAmms);
					PRINT 'Índice IX_SISUcsAmms_assetid creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISWProgram_dodn' AND object_id = OBJECT_ID('dbo.SISWProgram'))
				BEGIN
					CREATE INDEX IX_SISWProgram_dodn ON dbo.SISWProgram (dodn_SISWProgram);
					PRINT 'Índice IX_SISWProgram_dodn creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISWBuyer_dodn' AND object_id = OBJECT_ID('dbo.SISWBuyer'))
				BEGIN
					CREATE INDEX IX_SISWBuyer_dodn ON dbo.SISWBuyer (dodn_SISWBuyer);
					PRINT 'Índice IX_SISWBuyer_dodn creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISWSupplier_dodn' AND object_id = OBJECT_ID('dbo.SISWSupplier'))
				BEGIN
					CREATE INDEX IX_SISWSupplier_dodn ON dbo.SISWSupplier (dodn_SISWSupplier);
					PRINT 'Índice IX_SISWSupplier_dodn creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISReceiving_issuedocno' AND object_id = OBJECT_ID('dbo.SISReceiving'))
				BEGIN
					CREATE INDEX IX_SISReceiving_issuedocno ON dbo.SISReceiving (issuedocno_SISReceiving);
					PRINT 'Índice IX_SISReceiving_issuedocno creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISReceiving_documentnumber' AND object_id = OBJECT_ID('dbo.SISReceiving'))
				BEGIN
					CREATE INDEX IX_SISReceiving_documentnumber ON dbo.SISReceiving (documentnumber_SISReceiving);
					PRINT 'Índice IX_SISReceiving_documentnumber creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISShipping_issuedocno' AND object_id = OBJECT_ID('dbo.SISShipping'))
				BEGIN
					CREATE INDEX IX_SISShipping_issuedocno ON dbo.SISShipping (issuedocno_SISShipping);
					PRINT 'Índice IX_SISShipping_issuedocno creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISShipping_fkassetlcf' AND object_id = OBJECT_ID('dbo.SISShipping'))
				BEGIN
					CREATE INDEX IX_SISShipping_fkassetlcf ON dbo.SISShipping (fkassetlcf_SISShipping);
					PRINT 'Índice IX_SISShipping_fkassetlcf creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISSummaryAWB_pr' AND object_id = OBJECT_ID('dbo.SISSummaryAWB'))
				BEGIN
					CREATE INDEX IX_SISSummaryAWB_pr ON dbo.SISSummaryAWB (pr_SISSummaryAWB);
					PRINT 'Índice IX_SISSummaryAWB_pr creado.';
				END

				IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SISSummaryAWB_awb' AND object_id = OBJECT_ID('dbo.SISSummaryAWB'))
				BEGIN
					CREATE INDEX IX_SISSummaryAWB_awb ON dbo.SISSummaryAWB (awb_SISSummaryAWB);
					PRINT 'Índice IX_SISSummaryAWB_awb creado.';
				END

				PRINT 'Proceso de creación de índices finalizado.';
			END;
            ");

            // --- PROCEDIMIENTO BACKLOG ---
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[pro_updateammsbacklog]
            AS
            BEGIN
                SET NOCOUNT ON;

                DECLARE @fecha NVARCHAR(50) = CONVERT(NVARCHAR(50), GETDATE(), 106);

                UPDATE prog SET requestedby_SISWProgram = u.Nickname
                FROM dbo.SISWProgram AS prog JOIN dbo.AspNetUsers AS u ON CONCAT(u.LastName, ', ', u.FirstName) = prog.requestedby_SISWProgram;

                UPDATE buy SET buyer_SISWBuyer = u.Nickname, requestedby_SISWBuyer = u2.Nickname
                FROM dbo.SISWBuyer AS buy
                LEFT JOIN dbo.AspNetUsers AS u ON CONCAT(u.LastName, ', ', u.FirstName) = buy.buyer_SISWBuyer
                LEFT JOIN dbo.AspNetUsers AS u2 ON CONCAT(u2.LastName, ', ', u2.FirstName) = buy.requestedby_SISWBuyer;

                UPDATE sup SET requestedby_SISWSupplier = u.Nickname, buyer_SISWSupplier = u2.Nickname
                FROM dbo.SISWSupplier AS sup
                LEFT JOIN dbo.AspNetUsers AS u ON CONCAT(u.LastName, ', ', u.FirstName) = sup.requestedby_SISWSupplier
                LEFT JOIN dbo.AspNetUsers AS u2 ON CONCAT(u2.LastName, ', ', u2.FirstName) = sup.buyer_SISWSupplier;

                ;WITH SourceSuppliers AS (
                    SELECT *, ROW_NUMBER() OVER(PARTITION BY dodn_SISWSupplier ORDER BY edd_SISWSupplier DESC) AS RowNum
                    FROM dbo.SISWSupplier
                )
                MERGE INTO dbo.SISUcsAmms AS target
                USING (SELECT * FROM SourceSuppliers WHERE RowNum = 1) AS source
                ON target.requisition_SISUcsAmms = source.dodn_SISWSupplier
                WHEN MATCHED THEN
                    UPDATE SET
                        target.logremarks_SISUcsAmms = @fecha + ' - ' + source.source_SISWSupplier,
                        target.alternatepn_SISUcsAmms = IIF(source.partnumber_SISWSupplier != target.partnumber_SISUcsAmms, source.partnumber_SISWSupplier, target.alternatepn_SISUcsAmms),
                        target.lasteditedby_SISUcsAmms = source.requestedby_SISWSupplier,
                        target.ponumber_SISUcsAmms = ISNULL(source.ponumber_SISWSupplier, target.ponumber_SISUcsAmms),
                        target.priority_SISUcsAmms = source.priority_SISWSupplier,
                        target.company_SISUcsAmms = CASE WHEN source.projectid_SISWSupplier LIKE '7471%' THEN 'CONUS' WHEN source.projectid_SISWSupplier LIKE 'X7471%' THEN 'LOCAL' ELSE target.company_SISUcsAmms END,
                        target.budgete_SISUcsAmms = CASE WHEN source.projectid_SISWSupplier IN ('7471.05.5001.0000.CO', 'X471.06.05.5001.0000.CO') THEN 'CLIN 1' ELSE 'CLIN 8' END,
                        target.vendorcode_SISUcsAmms = ISNULL(source.vendorid_SISWSupplier, target.vendorcode_SISUcsAmms),
                        target.vendorname_SISUcsAmms = ISNULL(source.vendorname_SISWSupplier, target.vendorname_SISUcsAmms),
                        target.orderstatus_SISUcsAmms = source.bostatus_SISWSupplier,
                        target.purchasecondition_SISUcsAmms = ISNULL(source.pricetype_SISWSupplier, target.purchasecondition_SISUcsAmms),
                        target.podate_SISUcsAmms = ISNULL(source.orddate_SISWSupplier, target.podate_SISUcsAmms),
                        target.pureqqty_SISUcsAmms = ISNULL(source.ordqty_SISWSupplier, target.pureqqty_SISUcsAmms),
                        target.purchaseunit_SISUcsAmms = ISNULL(source.pouom_SISWSupplier, target.purchaseunit_SISUcsAmms),
                        target.edd_SISUcsAmms = IIF(source.edd_SISWSupplier > target.edd_SISUcsAmms OR target.edd_SISUcsAmms IS NULL, source.edd_SISWSupplier, target.edd_SISUcsAmms),
                        target.partinvcost_SISUcsAmms = source.estimatedunitprice_SISWSupplier,
                        target.buyer_SISUcsAmms = source.buyer_SISWSupplier;

                -- Prioridad 2: SISWBuyer (con manejo de duplicados)
                ;WITH SourceBuyers AS (
                    SELECT *, ROW_NUMBER() OVER(PARTITION BY dodn_SISWBuyer ORDER BY approveddate_SISWBuyer DESC) AS RowNum
                    FROM dbo.SISWBuyer
                )
                MERGE INTO dbo.SISUcsAmms AS target
                USING (SELECT * FROM SourceBuyers WHERE RowNum = 1) AS source
                ON target.requisition_SISUcsAmms = source.dodn_SISWBuyer
                WHEN MATCHED AND (target.logremarks_SISUcsAmms NOT LIKE '%Buyer%' AND target.logremarks_SISUcsAmms NOT LIKE '%Supplier%') THEN
                    UPDATE SET
                        target.logremarks_SISUcsAmms = @fecha + ' - ' + source.source_SISWBuyer,
                        target.ponumber_SISUcsAmms = ISNULL(source.ponumber_SISWBuyer, target.ponumber_SISUcsAmms),
                        target.lasteditedby_SISUcsAmms = source.requestedby_SISWBuyer,
                        target.priority_SISUcsAmms = source.priority_SISWBuyer,
                        target.orderstatus_SISUcsAmms = source.bostatus_SISWBuyer,
                        target.datercvdapp_SISUcsAmms = ISNULL(source.approveddate_SISWBuyer, target.datercvdapp_SISUcsAmms),
                        target.podate_SISUcsAmms = ISNULL(source.orddate_SISWBuyer, target.podate_SISUcsAmms),
                        target.partinvcost_SISUcsAmms = ISNULL(source.estimatedunitprice_SISWBuyer, target.partinvcost_SISUcsAmms),
                        target.buyer_SISUcsAmms = source.buyer_SISWBuyer;

                -- Prioridad 3: SISWProgram (con manejo de duplicados)
                ;WITH SourcePrograms AS (
                    SELECT *, ROW_NUMBER() OVER(PARTITION BY dodn_SISWProgram ORDER BY ponumber_SISWProgram DESC) AS RowNum
                    FROM dbo.SISWProgram
                )
                MERGE INTO dbo.SISUcsAmms AS target
                USING (SELECT * FROM SourcePrograms WHERE RowNum = 1) AS source
                ON target.requisition_SISUcsAmms = source.dodn_SISWProgram
                -- CORRECCIÓN: Se ajustaron los textos literales para que la lógica de prioridad funcione
                WHEN MATCHED AND (target.logremarks_SISUcsAmms IS NULL OR (target.logremarks_SISUcsAmms NOT LIKE '%Buyer%' AND target.logremarks_SISUcsAmms NOT LIKE '%Supplier%')) THEN
                    UPDATE SET
                        target.logremarks_SISUcsAmms = @fecha + ' - ' + source.source_SISWProgram,
                        target.ponumber_SISUcsAmms = ISNULL(source.ponumber_SISWProgram, target.ponumber_SISUcsAmms),
                        target.orderstatus_SISUcsAmms = source.bostatus_SISWProgram,
                        target.priority_SISUcsAmms = source.priority_SISWProgram;

                UPDATE dbo.SISUcsAmms
                SET extendcost_SISUcsAmms = pureqqty_SISUcsAmms * partinvcost_SISUcsAmms
                WHERE extendcost_SISUcsAmms IS NULL OR extendcost_SISUcsAmms != (pureqqty_SISUcsAmms * partinvcost_SISUcsAmms);

            END;
            ");

            // --- PROCEDIMIENTO RECEIVING ---
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[pro_updateammsreceiving]
            AS
            BEGIN
                SET NOCOUNT ON;

                -- Usamos un CTE para pre-agregar los datos de recepción, manejando duplicados
                -- y consolidando la lógica de los joins por 'issuedocno' y 'documentnumber'.
                WITH ReceivingData AS (
                    SELECT
                        -- Usamos COALESCE para obtener el número de requisición de cualquiera de las dos columnas
                        COALESCE(r.issuedocno_SISReceiving, r.documentnumber_SISReceiving) AS Requisition,
                        SUM(r.receiptqty_SISReceiving) AS TotalReceivedQty,
                        MAX(r.reclinedate_SISReceiving) AS LastReceiveDate,
                        MAX(r.assetid_SISReceiving) AS LastAssetId,
                        -- Determinamos el estado final. Si cualquier recepción es 'TRANSFER', ese será el estado.
                        MAX(CASE
                            WHEN r.receipttype_SISReceiving = 'TRANSFER' THEN 'TRANSFER'
                            ELSE 'AWAITING TRANS'
                            END) AS FinalStatus
                    FROM dbo.SISReceiving AS r
                    -- Nos aseguramos de procesar solo las filas que tienen una requisición válida
                    WHERE COALESCE(r.issuedocno_SISReceiving, r.documentnumber_SISReceiving) IS NOT NULL
                    GROUP BY COALESCE(r.issuedocno_SISReceiving, r.documentnumber_SISReceiving)
                )
                -- Ahora, usamos MERGE para actualizar la tabla principal en un solo paso.
                -- MERGE es más seguro que UPDATE aquí, ya que solo actúa si encuentra una coincidencia.
                MERGE INTO dbo.SISUcsAmms AS target
                USING ReceivingData AS source
                ON target.requisition_SISUcsAmms = source.Requisition
                WHEN MATCHED THEN
                    UPDATE SET
                        target.earecinffinbound_SISUcsAmms = source.TotalReceivedQty,
                        target.receiveddateff_SISUcsAmms = source.LastReceiveDate,
                        target.assetid_SISUcsAmms = ISNULL(source.LastAssetId, target.assetid_SISUcsAmms),
                        target.orderstatus_SISUcsAmms = source.FinalStatus,
                        target.logremarks_SISUcsAmms = NULL; -- Se limpia el log remark según la lógica original
            END;
            ");

            // --- PROCEDIMIENTO SHIPPING ---
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[pro_updateammsshipping]
            AS
            BEGIN
                SET NOCOUNT ON;
                DECLARE @fecha NVARCHAR(50) = CONVERT(NVARCHAR(50), GETDATE(), 106);

                WITH ShippingData AS (
                    SELECT
                        -- La JoinKey se mantiene como NVARCHAR, que es lo correcto.
                        COALESCE(s.issuedocno_SISShipping, CAST(s.fkassetlcf_SISShipping AS NVARCHAR(36))) AS JoinKey,
                        SUM(s.shippedqty_SISShipping) AS TotalQty,
                        MAX(s.shippeddatetime_SISShipping) AS LastShipDate,
                        MAX(CASE WHEN s.mawb_SISShipping IS NOT NULL THEN s.mawb_SISShipping END) AS LastAwb,
                        MAX(s.linestatus_SISShipping) AS LastStatus
                    FROM dbo.SISShipping s
                    WHERE s.linestatus_SISShipping != 'CANCELED'
                      AND (
                          EXISTS (SELECT 1 FROM dbo.SISUcsAmms upd WHERE upd.requisition_SISUcsAmms = s.issuedocno_SISShipping)
                          -- CORRECCIÓN 1: Se convierte el assetid de la tabla a NVARCHAR para la comparación.
                          OR EXISTS (SELECT 1 FROM dbo.SISUcsAmms upd WHERE CAST(upd.assetid_SISUcsAmms AS NVARCHAR(36)) = CAST(s.fkassetlcf_SISShipping AS NVARCHAR(36)))
                      )
                    GROUP BY COALESCE(s.issuedocno_SISShipping, CAST(s.fkassetlcf_SISShipping AS NVARCHAR(36)))
                )
                UPDATE target
                SET
                    target.earecinffinbound_SISUcsAmms = source.TotalQty,
                    target.estdatedeparturet4_SISUcsAmms = source.LastShipDate,
                    target.awb_SISUcsAmms = ISNULL(source.LastAwb, target.awb_SISUcsAmms),
                    target.orderstatus_SISUcsAmms = 'SHIPPING - ' + ISNULL(source.LastStatus, ''),
                    target.logremarks_SISUcsAmms = @fecha + ' - SHIPPING - ' + ISNULL(source.LastStatus, '')
                FROM dbo.SISUcsAmms AS target
                JOIN ShippingData AS source
                -- CORRECCIÓN 2: Se convierte el assetid de la tabla a NVARCHAR para el JOIN.
                ON target.requisition_SISUcsAmms = source.JoinKey
                   OR CAST(target.assetid_SISUcsAmms AS NVARCHAR(36)) = source.JoinKey
                WHERE source.LastStatus IS NOT NULL;
            END;
            ");

            // --- PROCEDIMIENTO AWB ---
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[pro_updateammsawb]
            AS
            BEGIN
                SET NOCOUNT ON;

                WITH AwbSummary AS (
                    SELECT
                        a.pr_SISSummaryAWB AS Requisition,
                        MAX(a.datereceived_SISSummaryAWB) AS LastReceivedDate,
                        SUM(a.qty_SISSummaryAWB) AS TotalQtyReceived,
                        MAX(a.awb_SISSummaryAWB) AS LastAwb
                    FROM dbo.SISSummaryAWB AS a
                    WHERE a.pr_SISSummaryAWB IS NOT NULL
                    GROUP BY a.pr_SISSummaryAWB
                )
                UPDATE target
                SET
                    target.logremarks_SISUcsAmms =
                        CONVERT(NVARCHAR(20), source.LastReceivedDate, 106) +
                        ' - RCVD in GYM - ' +
                        source.LastAwb +
                        CASE
                            WHEN target.pureqqty_SISUcsAmms <= source.TotalQtyReceived THEN ' Order complete'
                            ELSE ' Partial delivery'
                        END,
                    target.orderstatus_SISUcsAmms = 'RECEIVED'
                FROM dbo.SISUcsAmms AS target
                -- CORRECCIÓN: Se actualizó el JOIN para usar el nuevo nombre del CTE
                JOIN AwbSummary AS source
                    ON target.requisition_SISUcsAmms = source.Requisition;
            END;
            ");

            // --- PROCEDIMIENTO ORQUESTADOR ---
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[pro_ExecuteDailyReportUpdates]
            AS
            BEGIN
                SET NOCOUNT ON;

                PRINT '== INICIANDO PROCESO DE ACTUALIZACIÓN DIARIO ==';

                BEGIN TRY
                    PRINT 'Paso 1: Actualizando desde MRO (Programs, Buyers, Suppliers)...';
                    EXEC dbo.pro_updateammsbacklog;
                    PRINT 'Paso 1 completado exitosamente.';

                    PRINT 'Paso 2: Actualizando desde Receiving...';
                    EXEC dbo.pro_updateammsreceiving;
                    PRINT 'Paso 2 completado exitosamente.';

                    PRINT 'Paso 3: Actualizando desde Shipping...';
                    EXEC dbo.pro_updateammsshipping;
                    PRINT 'Paso 3 completado exitosamente.';

                    PRINT 'Paso 4: Actualizando desde AWB Summary...';
                    EXEC dbo.pro_updateammsawb;
                    PRINT 'Paso 4 completado exitosamente.';

                    PRINT '== PROCESO DE ACTUALIZACIÓN DIARIO FINALIZADO CON ÉXITO ==';
                END TRY
                BEGIN CATCH
                    -- Este bloque captura cualquier error en los procedimientos llamados
                    PRINT '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!';
                    PRINT '¡ERROR! El proceso de actualización ha fallado.';
                    PRINT 'Error en el procedimiento: ' + ERROR_PROCEDURE();
                    PRINT 'Número de error: ' + CAST(ERROR_NUMBER() AS VARCHAR);
                    PRINT 'Mensaje de error: ' + ERROR_MESSAGE();
                    PRINT '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!';

                    -- Es importante relanzar el error para que el sistema que lo llamó (como el Agente SQL) sepa que la tarea falló.
                    THROW;
                END CATCH
            END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pro_createindex]");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pro_updateammsbacklog]");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pro_updateammsreceiving]");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pro_updateammsshipping]");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pro_updateammsawb]");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[pro_ExecuteDailyReportUpdates]");
        }
    }
}
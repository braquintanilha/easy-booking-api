#!/bin/bash

# Variáveis de conexão com o banco de dados
DB_SERVER="localhost"
DB_PORT="1433"
DB_USER="sa"
DB_PASSWORD="s3nh4s3cr3t4!!"

# Caminho para os scripts SQL
SCRIPTS_DIR="/docker-entrypoint-initdb.d"

# Comando SQLCMD para executar os scripts no banco de dados "master"
SQLCMD_MASTER="/opt/mssql-tools/bin/sqlcmd -S $DB_SERVER,$DB_PORT -U $DB_USER -P $DB_PASSWORD -d master -i"

# Comando SQLCMD para executar os scripts no banco de dados "EasyBooking"
SQLCMD_EASYBOOKING="/opt/mssql-tools/bin/sqlcmd -S $DB_SERVER,$DB_PORT -U $DB_USER -P $DB_PASSWORD -d EasyBooking -i"

# Executar o script create-db.sql no banco de dados "master"
$SQLCMD_MASTER $SCRIPTS_DIR/create-db.sql

# Executar o script init-data.sql no banco de dados "EasyBooking"
$SQLCMD_EASYBOOKING $SCRIPTS_DIR/init-data.sql

# Sair
exit 0

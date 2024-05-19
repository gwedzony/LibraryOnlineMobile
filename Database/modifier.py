import re

def convert_sqlite_to_mysql(input_file, output_file):
    with open(input_file, 'r') as file:
        data = file.read()

    # Usuń linie zawierające PRAGMA, BEGIN TRANSACTION i COMMIT
    data = re.sub(r'^PRAGMA.*;$', '', data, flags=re.MULTILINE)
    data = re.sub(r'^BEGIN TRANSACTION;$', '', data, flags=re.MULTILINE)
    data = re.sub(r'^COMMIT;$', '', data, flags=re.MULTILINE)

    # Zamień typy danych
    data = data.replace("INTEGER", "INT")
    data = data.replace("TEXT", "VARCHAR(255)")
    data = data.replace("REAL", "FLOAT")
    data = data.replace("BLOB", "LONGBLOB")

    # Usuń podwójne cudzysłowy wokół identyfikatorów
    data = re.sub(r'"([^"]*)"', r'`\1`', data)

    with open(output_file, 'w') as file:
        file.write(data)

convert_sqlite_to_mysql('dump.sql', 'modified_dump.sql')

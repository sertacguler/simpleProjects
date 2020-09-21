import ibm_db

conn=ibm_db.connect("DATABASE=DBNAME;HOSTNAME=192.168.1.220;PORT=50002;PROTOCOL=TCPIP;UID=admin;PWD=pass12345",'','')
connState = ibm_db.active(conn)

print(connState)

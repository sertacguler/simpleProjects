import ibm_db

conn=ibm_db.connect("DATABASE=DBNAME;HOSTNAME=192.168.1.220;PORT=50002;PROTOCOL=TCPIP;UID=admin;PWD=pass12345",'','')

sql = "SELECT * FROM ACFILES"
stmt = ibm_db.exec_immediate(conn, sql)
dictionary = ibm_db.fetch_both(stmt)
print ("The Name is : ", dictionary[0])
while dictionary != False:
	print ("The Name is : ", dictionary)
	dictionary = ibm_db.fetch_both(stmt)
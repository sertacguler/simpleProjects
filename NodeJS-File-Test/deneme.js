"use strict";

var fs = require("fs");

fs.watch("SavedCopies",function(event,filename){ // Klasorde degisiklik varsa
	console.log("event : ", event); // degisiklige ne sebep olmus
	// Dosya olusturma, tasima, silme (rename)
	// dosya yetkileri (change)
	console.log("filename : ", filename); // degisiklige sebep olan dosyanın yolu

	// degisiklik olan klasordeki verileri okuma
	fs.readFile(('SavedCopies/'+filename),"utf-8",function(ex,data){
		if(ex){
		console.log(ex);
		}else{
		console.log(data);
		}
	});
	
});

// olusan bir dosyanın yolu ornek
// SavedCopies/TCP_192.168.1.220_33897-1578991142-4827-NCEToHost.txt
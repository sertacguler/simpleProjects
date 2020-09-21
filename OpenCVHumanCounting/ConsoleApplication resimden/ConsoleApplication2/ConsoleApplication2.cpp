#include "stdafx.h"
#include <opencv2/objdetect/objdetect.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp> 
#include <iostream>
#include <stdio.h>
#include <time.h>
#include <string>
#include <fstream>
#include <ctime>
#include <conio.h>
#include <windows.h>



using namespace std;
using namespace cv;

//Burada fonksiyonlar tanımlandı
//Görüntüden alınan verileri .txt dosyasına kaydetmek için
void FileWriteSw(int a,int b);
int a = 0;
string ZamanFnc();
string ZamanFnc2();
//Burada ne zaman kaydedildiğini hesaplıyor

int main(int argc, char** argv)
{

	static CvMemStorage* storage = cvCreateMemStorage(0);

	//Burada her bir nesne(canlı) için cascade oluşturuldu
	static CvHaarClassifierCascade* cascade = 0;
	static CvHaarClassifierCascade* cascade1 = 0;
	static CvHaarClassifierCascade* cascade2 = 0;

	//Burada nesnelerin .xml uzantılı dosyaları tanımlandı
	cascade = (CvHaarClassifierCascade*)cvLoad("XML/bird.xml", 0, 0, 0);
	cascade1 = (CvHaarClassifierCascade*)cvLoad("XML/yuz_tani.xml", 0, 0, 0);
	cascade2 = (CvHaarClassifierCascade*)cvLoad("XML/cars.xml", 0, 0, 0);

	//Burada sorgulanan tanımlanan .xml dosyalarının varmı diye kontrol
	if (!cascade)
	{
		fprintf(stderr, "ERROR: Could not load 'classifier cascade'\n");
		system("PAUSE");
		return -1;
	}
	if (!cascade1)
	{
		fprintf(stderr, "ERROR: Could not load 'classifier cascade'\n");
		system("PAUSE");
		return -1;
	}
	if (!cascade2)
	{
		fprintf(stderr, "ERROR: Could not load 'classifier cascade'\n");
		system("PAUSE");
		return -1;
	}

	//Dosyadan resimlerin isimleri alınacak
	ifstream list("RESIM/list.txt");
	//Dosya açıldımı sorgusu
	if (list.is_open() == false){
		cout << "can't open the file" << endl;
		exit(EXIT_FAILURE);
	}
	string line;//Dosyadan gelen veriyi buna atayacaz	

	//Dosyadan veriler saır satır çekiliyor
	while (getline(list, line)) {

		const char* metin = line.c_str();
		//Dosyadna alınan resim isimleri string olarak alınıyor ve char a dönüştürülüyor
		//line okunan veri


		IplImage* frame = cvLoadImage(metin, 1), *img;//Burada resim frame olarak kare yani alınıyor
		if (!frame)//kare varmı resim varmı gibi
			break;

		img = cvCloneImage(frame);//burayı bilmiyorum orjinal resmi saklıyor galiba diğerini boyuyor
		img->origin = 0;
		if (frame->origin) cvFlip(img, img);
		cvClearMemStorage(storage);

		//Burada belirlenen nesnenin sayısı yeri boyutu galiba
		CvSeq* bird = cvHaarDetectObjects(img, cascade, storage, 1.1, 2, CV_HAAR_DO_CANNY_PRUNING, cvSize(20, 20));
		CvSeq* faces = cvHaarDetectObjects(img, cascade1, storage, 1.1, 2, CV_HAAR_DO_CANNY_PRUNING, cvSize(20, 20));
		CvSeq* cars = cvHaarDetectObjects(img, cascade2, storage, 1.1, 2, CV_HAAR_DO_CANNY_PRUNING, cvSize(20, 20));
		
		//Burada resimdeki nesneye göre renk belirlenir ve şekil çizilir
		for (int i = 0; i < (bird ? bird->total : 0); i++) {
			CvRect* r = (CvRect*)cvGetSeqElem(bird, i);
			cvRectangle(img, cvPoint(r->x, r->y), cvPoint(r->x + r->width, r->y + r->height), CV_RGB(0, 0, 255), 3);
		}
		for (int i = 0; i < (faces ? faces->total : 0); i++) {
			CvRect* r = (CvRect*)cvGetSeqElem(faces, i);
			cvRectangle(img, cvPoint(r->x, r->y), cvPoint(r->x + r->width, r->y + r->height), CV_RGB(255,74, 74), 3);
		}
		for (int i = 0; i < (cars ? cars->total : 0); i++) {
			CvRect* r = (CvRect*)cvGetSeqElem(cars, i);
			cvRectangle(img, cvPoint(r->x, r->y), cvPoint(r->x + r->width, r->y + r->height), CV_RGB(255, 255, 255), 3);
		}

		ofstream outDos("shaka.txt");//Verilerin kaydedileceği klasörün adı
		FileWriteSw((bird ? bird->total : 0), 0); //dosyaya yazma 2 parametre gönderiyor 
		FileWriteSw((faces ? faces->total : 0),1);//1. parametre kaçtane nesne yakalandı
		FileWriteSw((cars ? cars->total : 0), 2);//2. parametre yakalanan nesnenin türü
		
		cvShowImage("Yuz", img);//Ekranda göstermesi için
		cvReleaseImage(&img);

		Sleep(5000);//Resim aralarında 5sn beklemesi için
		
		if (waitKey(30) == 27)
			break;//Çıkmak için siyah ekrana bastıktan sonra ESC'ye basarak çıkılıyor
	}
	system("PAUSE");
	return 0;
}

void FileWriteSw(int a,int b)
{

	ofstream filex("shaka.txt", ios::app);

	if (b == 0){
		filex << "Kus ";
		filex << a <<" ";
		filex << ZamanFnc() << endl ;
	}
	if (b == 1){
		filex << "Insan ";
		filex << a << " ";
		filex << ZamanFnc() << endl;
	}
	if (b == 2){
		filex << "Araba ";
		filex << a << " ";
		filex << ZamanFnc() << endl;
	}
	filex.close();
}

void FileReadSw()
{
	ifstream filexread;
	filexread.open("sanatsal_cplus.txt", ios::in);
	string writext, writext2;
	//filexread.seekg(11, filexread.beg);
	while (!filexread.eof())//satır sonuna kadar oku
	{
		getline(filexread, writext);//satır satır oku
		cout << writext << "\n";

	}
	filexread.close();
}

string ZamanFnc()
{
	struct tm newtime;
	__time64_t timex;
	_time64(&timex);
	_localtime64_s(&newtime, &timex);

	if (newtime.tm_hour == 0)
		newtime.tm_hour = 00;
	int day1, month1, year1, hours1, minutes1, seconds1;
	day1 = newtime.tm_mday;
	month1 = newtime.tm_mon + 1;
	year1 = newtime.tm_year + 1900;
	hours1 = newtime.tm_hour;
	minutes1 = newtime.tm_min;
	seconds1 = newtime.tm_sec;
	string zaman1 = to_string(day1);
	zaman1 += ".";
	zaman1 += to_string(month1);
	zaman1 += ".";
	zaman1 += to_string(year1);
	zaman1 += " - ";
	zaman1 += to_string(hours1);
	zaman1 += ":";
	zaman1 += to_string(minutes1);
	zaman1 += ":";
	zaman1 += to_string(seconds1);

	return zaman1;
}

string ZamanFnc2()
{
	struct tm newtime;
	__time64_t timex;
	char timeas[26];
	_time64(&timex);
	_localtime64_s(&newtime, &timex);

	if (newtime.tm_hour == 0)
		newtime.tm_hour = 00;
	asctime_s(timeas, 26, &newtime);
	int day1, month1, year1, hours1, minutes1, seconds1;
	day1 = newtime.tm_mday;
	month1 = newtime.tm_mon + 1;
	year1 = newtime.tm_year + 1900;
	hours1 = newtime.tm_hour;
	minutes1 = newtime.tm_min;
	seconds1 = newtime.tm_sec;
	string zaman1 = timeas;

	return zaman1;
}
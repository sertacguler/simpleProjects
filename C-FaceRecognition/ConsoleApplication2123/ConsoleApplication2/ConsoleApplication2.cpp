#include "stdafx.h"
#include <opencv2/objdetect/objdetect.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp> 
#include <iostream>
#include <stdio.h>

using namespace std;
using namespace cv;
int main(int argc, const char** argv)
{
	CascadeClassifier nesne;
	nesne.load("haarcascade_profileface.xml");
	VideoCapture vid;
	vid.open(0);

	if (!vid.isOpened())
	{
		cout << "webcam yuklenemedi" << endl;
		system("Pause");
		return -1;
	}
	Mat frame;
	Mat grires;
	namedWindow("algilanan", 1);

	while (true)
	{
		vid >> frame;
		cvtColor(frame, grires, CV_BGR2GRAY);  //resmi gri renk uzayına çevirir. 
		//equalizeHist(grires, grires); //istenirse histogram eşitlenir. 
		vector<Rect> nesvek;
		nesne.detectMultiScale(grires, nesvek, 1.1, 3, 0, Size(30, 30));
		for (int i = 0; i < nesvek.size(); i++)
		{
			Point pt1(nesvek[i].x + nesvek[i].width, nesvek[i].y + nesvek[i].height);
			Point pt2(nesvek[i].x, nesvek[i].y);
			rectangle(frame, pt1, pt2, cvScalar(0, 255, 0, 0), 1, 8, 0);
		}
		imshow("algilanan", frame);
		if(waitKey(30) == 27)
			break;
	}
	return 0;
}
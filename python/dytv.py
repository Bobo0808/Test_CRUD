#File name is dytv stands for download Youtube videos

import os
from pytube import YouTube

def Download(parURL):
    objYouTube = YouTube(parURL)
    objYoutube_HR = objYouTube.streams.get_highest_resolution()

    try:
        objYoutube_HR.download(output_path=f"{os.environ['UserProfile']}/Desktop/Youtube Videos")

    except:
        print("下載失敗")

    print("已下載成功")

strURL = input("請輸入 YouTube 影片的網址 :")
Download(strURL)

os.system("pause")
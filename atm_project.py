para = 2000

while True:
    print("""
        [1] Para Çekme
        [2] Para Yatırma
        [3] Kart Bilgileri
        [4] Kart İade
    """)
    islem = int(input("Yapmak istediğiniz işlemi seçiniz: "))

    if islem == 1:
        paraCek = int(input("Kaç para çekmek istiyorsunuz: "))
        if para >= paraCek:
            print("Eski para: {}\nYeni para: {}".format(para,para-paraCek))
            para -= paraCek
        else:
            print("Yeterli bakiyeniz yok")
    elif islem == 2:
        paraYatir = int(input("Kaç para yatırmak istiyorsunuz: "))
        print("Eski para: {}\nYeni para: {}".format(para,para+paraYatir))
        para += paraYatir
    elif islem == 3:
        print("Ad-Soyad: {}\nHesabınızdaki para miktarı: {}".format("Efe Emre İpek",para))
    else:
        print("Kart iade ediliyor")
        break

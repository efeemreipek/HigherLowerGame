def ebobAl(sayi1,sayi2):
    for i in range(1,min(sayi1,sayi2)+1):
        if sayi1 % i == 0 and sayi2 % i == 0:
            bolenler.append(i)

    return bolenler[len(bolenler)-1]        

bolenler = []

sayi1 = int(input("1. sayıyı giriniz: "))
sayi2 = int(input("2. sayıyı giriniz: "))

print("{}-{} sayılarının ebobu: {} ".format(sayi1,sayi2,ebobAl(sayi1,sayi2)))

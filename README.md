PhoneBook uygulamasi

Sistem iki farkli aray�ze sahip olacaktir.
? Herkese a�ik aray�z (bundan sonra PublicUI olarak adlandirilacaktir)
? Sadece Admin tarafindan girilebilen aray�z (bundan sonra AdminUI olarak
adlandirilacaktir)
? �alisanin ad, soyad, telefon, departman ve y�netici bilgileri sistemde yer alacaktir.
? PublicUI sadece sistemde kayitli �alisanlarin adlarini ve telefon numaralarini
barindiran bir liste g�sterecektir. Buradan bir �alisan se�ilmesi durumunda �alisana ait
detay bilgi g�sterimi yapilacaktir.
? AdminUI i�in gerek sifre degistirilebilir olacaktir.
? AdminUI aray�z�nden yeni �alisan girisi yapilabilecektir.
? �alisanin ad, soyad ve telefon bilgisinin girilmesi zorunludur.
? Departman bilgisi, veritabanindan alinarak dropdownlist�ten se�tirilecektir.
? Y�netici bilgisi, dropdownlist�ten se�tirilecektir. Bu dropdownlist sistemde mevcut
bulunan �alisan kayitlari �zerinden doldurulacaktir.
? �alisan kayitlari AdminUI �zerinden d�zenlenebilecek ve silinebilecektir. Kural olarak
eger ilgili �alisan baska bir �alisanin y�neticisi stat�s�nde bulunuyor ise silme islemine
izin verilmeyecektir.

? Sistemde kayitli bulanan departmanlar y�netilebilir olacaktir. Ekleme, D�zenleme ve
Silme islemlerine izin verilecektir. Kural olarak ilgili departmanin altinda tanimli
�alisan varsa departman silinemeyecektir.
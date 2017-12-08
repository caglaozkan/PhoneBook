PhoneBook uygulamasi

Sistem iki farkli arayüze sahip olacaktir.
? Herkese açik arayüz (bundan sonra PublicUI olarak adlandirilacaktir)
? Sadece Admin tarafindan girilebilen arayüz (bundan sonra AdminUI olarak
adlandirilacaktir)
? Çalisanin ad, soyad, telefon, departman ve yönetici bilgileri sistemde yer alacaktir.
? PublicUI sadece sistemde kayitli çalisanlarin adlarini ve telefon numaralarini
barindiran bir liste gösterecektir. Buradan bir çalisan seçilmesi durumunda çalisana ait
detay bilgi gösterimi yapilacaktir.
? AdminUI için gerek sifre degistirilebilir olacaktir.
? AdminUI arayüzünden yeni çalisan girisi yapilabilecektir.
? Çalisanin ad, soyad ve telefon bilgisinin girilmesi zorunludur.
? Departman bilgisi, veritabanindan alinarak dropdownlist’ten seçtirilecektir.
? Yönetici bilgisi, dropdownlist’ten seçtirilecektir. Bu dropdownlist sistemde mevcut
bulunan çalisan kayitlari üzerinden doldurulacaktir.
? Çalisan kayitlari AdminUI üzerinden düzenlenebilecek ve silinebilecektir. Kural olarak
eger ilgili çalisan baska bir çalisanin yöneticisi statüsünde bulunuyor ise silme islemine
izin verilmeyecektir.

? Sistemde kayitli bulanan departmanlar yönetilebilir olacaktir. Ekleme, Düzenleme ve
Silme islemlerine izin verilecektir. Kural olarak ilgili departmanin altinda tanimli
çalisan varsa departman silinemeyecektir.
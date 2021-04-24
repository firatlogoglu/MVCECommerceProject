# E-Commerce/E-Ticaret MVC Projesi

## Oluşturulan Katmanlar

### 1 - MVCECommerceProject.CORE
#### 1.1 - Entity
* IEntity: Tüm entitylerimizde yer alan ID'yi T tipine verdim, böylece dışardan herhangi bir tip alabilecek.
* CoreEntity: Tüm etitylerimizde yer alacak özellikler (Genel Durum vs.) tanımladım. Burda ID'yi Guid tipini verdim. Bu class ilk tetiklendiğinde otomatik olarak: Genel Durum(GenerelStatus) = Aktif. Oluşturma tarihi, Uuşturan kişinin çeşitli bilgileri burada otomatik olarak ctor metotuyla doldurulacak. 
#### 1.2 - Enums
* GeneralStatus(Genel Durumlar): Aktif, Update ve Deleted. Enum listesi olarak tanımlanıp 1.1 Entity içerisindeki CoreEntity içerisine verilmiştir.
#### 1.3 - Map
* CoreMap: CoreEntity içerisindeki özelliklere çeşitli isimledirmeler ve sınırlandırılmalar verilmiştir.
#### 1.4 - Service
* ICoreService: Tüm service'lerde bulunan ortak eylemler tanımlandı.
### 2 - MVCECommerceProject.MODEL
#### 2.1 - Entities
* 2.1.1 AppUser
* 2.1.2 Category
* 2.1.3 Order
* 2.1.4 OrderDetail
* 2.1.5 Product
* 2.1.6 SubCategory
#### 2.2 - Enums
* Role	 
* BloodType
* Gender
* MaritalState
#### 2.3 - Map
* AppUserMap:
* CategoryMap:
* OrderDetailMap:
* OrderMap:
* ProductMap:
* SubCategoryMap:
#### 2.4 - Context
* ProjectContext:
* SampleData:
#### 2.5 - Migrations
* Configuration içerisine 2.4 Context içerisinde yer alan SampleData instance alınarak Seed metotun içerisine verilmiştir.

#### 2.6 - CartModel
* Cart
* CartItem

### 3 - MVCECommerceProject.SERVICE/BLL (İş Katmanı) 
#### 3.1 - Base
* BaseSerice: Tüm Etitylerde bulunan belli başlı CRUD ve Listeleme işlemleri tanımlanmıştır.
#### 3.2 - Options
* AppUserService:
* CategoryService:
* OrderDetailService:
* OrderService:
* ProductService:
* SubCategoryService:
### 4 - MVCECommerceProject.MVC (Sunum Katmanı)

#### 4.1 - Filters
* AuthorizationFilters/CustomerAuthFilter:
* AuthorizationFilters/ManegementAuthFilter:
* AuthorizationFilters/SellerAuthFilter:

#### 4.2 - Giriş Area'sı

##### 4.2.1 - Controllers ve Views
* Home: Index, About ve Contact.
* Product: Index, Details, FindCategoryProducts, FindSubCategoryProducts ve FindSellerProducts.
* Sellers: Index, Find, Products ve TableProducts.
* Buy: Index ve SepeteEkle.

##### NOT: "Hemen Satın Al" işleminde ürün bilgisi Customer Area'yasına eklenecek.

##### 4.2.2 - Views/Shared/
* _Layout:
* Error:
* PartialViews/Sidebar: _Sidebar, _ContactAboutSidebar, _ProductsSellersSidebar, _LoginSidebar ve _LogoutSidebar. 
* PartialViews/TopNavbar: _TopNavbar, _MyCart, _Alerts ve _SpecialDays.
* PartialViews/Messages: _ErrorMsg ve _SuccessMsg.
* PartialViews/_About:
* PartialViews/_Contact:
* PartialViews/_Footer:
* PartialViews/_PageTop:

##### NOT: _SpecialDays için resim veya fotoğraf bulunacak.

#### 4.3 - Customer Area'sı

##### 4.3.1 - Controllers ve Views
* Account: Register, Login, ForgotPassword, Index ve Edit.
* Home: Index, About ve Contact.
* Product: Index, Details, FindCategoryProducts, FindSubCategoryProducts, FindSellerProducts ve CustomerProducts.
* Seller: Index, Find, Products ve TableProducts.
* Buy: Index, SepeteEkle ve Create.
* Order: Index ve OrderDetails.

##### NOT: "Hemen Satın Al" işleminde ürün bilgisi Customer Area'yasına eklenecek.

##### NOT: Sipariş işlemleri tamamlanacak.

##### 4.3.2 - Views/Shared/
* _Layout:
* PartialViews/Sidebar: _Sidebar, _OthersMenusSidebar ve _ProductsSellersSidebar. 
* PartialViews/TopNavbar: _TopNavbar ve _MyMsg.
* PartialViews/_Footer:

#### 4.4 - Seller Area'sı

##### 4.4.1 - Controllers ve Views
* Account: Login, ForgotPassword, Index ve Edit.
* Home: Index, About ve Contact.
* Product: Index, Create, Edit ve Delete.
* Category: Index.

##### 4.4.2 - Views/Shared/
* _Layout:
* PartialViews/Sidebar: _Sidebar ve _SellerOthersMenusSidebar.
* PartialViews/TopNavbar: _TopNavbar.
* PartialViews/_Footer:

#### 4.5 - Manegement Area'sı

##### 4.5.1 - Controllers ve Views
* Account: Login, ForgotPassword, Index ve Edit.
* Home: Index, About ve Contact.
* Customer: Index, Create, Details, Edit, Delete ve ResetPassword.
* Seller: Index, Create, Details, Edit, Delete ve ResetPassword.
* Product: Index, Create, Details, Edit, Delete, FindCategoryProducts, FindSubCategoryProducts ve FindSellerProducts.
* Category: Index, Create, Details, Edit ve Delete.
* SubCategory: Index, Create, Details, Edit ve Delete. 

##### 4.5.2 - Views/Shared/
* _Layout:
* PartialViews/Sidebar: _Sidebar ve _ManegementOthersMenusSidebar.
* PartialViews/TopNavbar: _TopNavbar.
* PartialViews/_Footer:

### 5 - MVCECommerceProject.COMMON
#### Tools/Araçlar
* ImagesUploader/Resim Yükleyicisi
* MailSender/E-Posta Göndericisi


## Bu Proje İçerisine Dahil Edilen ve Kullanılan Temalar

### 1.) Start Bootstrap - SB Admin 2
* [Start Bootstrap - SB Admin 2](https://startbootstrap.com/theme/sb-admin-2/)
* [Start Bootstrap - SB Admin 2 - GitHub](https://github.com/startbootstrap/startbootstrap-sb-admin-2)

### 2.) Start Bootstrap - Shop Item (kullanılmıyor)
* [Start Bootstrap - Shop Item](https://startbootstrap.com/template/shop-item/)
* [Start Bootstrap - Shop Item - GitHub](https://github.com/startbootstrap/startbootstrap-shop-item)

## Çalıştırılmadan Önce Yapılacak Ayarlar
* 1.) MVCECommerceProject.MVC'nin ilk etapta başlangıç projesi yapılması gerekiyor: Çözüm Gezgini'de (Solution Explorer'da) MVCECommerceProject.MVC’a Sağ tıklayıp. “Set as StartUp Project/Başlangıç Projesi Olarak Ayarla” ya tıkla. 

* 2.) SQL Database Server'ın yolu varsayılan olarak ayarlıdır ("server=.;database=MVCECommerceProjectDB;uid=sa;pwd=123"). Bu yolu, MVCECommerceProject.MODEL/Context/ProjectContext.cs dosyası içerisinde değiştirebilirsiniz.

* 3.) Bu programın e-posta gönderebilmesi (gönderici) için, MVCECommerceProject.COMMON/MyTools/MailSender.cs dosyasının ayarlanması gerekiyor.

* 4.) SampleData içerisindeki veriler kullanıcaksa, sahte (fake) e-posta adreslerine, e-posta gönderecektir. Bu e-posta adresleri kullanılan ve başkasına ait olabilir. Bunu engellemek için, MVCECommerceProject.COMMON/MyTools/MailSender.cs dosyası içerisindeki //email = ""; yorum satırından çıkarılıp, içerisine alcı e-posta adresi olarak kendi e-posta adresinizi eklemek zorundasınız.

## Projedeki Eksik Yerler
* 1.) Kargo bilgisi eklenmediği için, satış işlemleri tamamlanmıştır.

* 2.) Giriş yapılmadan, "Hemen Satın Al" işleminde ürün bilgisi Customer Area'yasına taşınmalı.

* 3.) SpecialDays (Özel Günler) için, resim veya fotoğraf bulunacak.
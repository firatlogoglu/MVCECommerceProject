﻿# E-Commerce/E-Ticaret MVC Projesi

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
#### 2.3 - Map
* AppUserMap:
* CategoryMap:
* OrderDetailMap:
* OrderMap:
* ProductMap:
* SubCategoryMap:
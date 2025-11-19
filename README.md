# MyAcademyBlogProject

### 🏗️ Genel Özellikler
---------------------------------------------------------
- 🧑‍💻 **Kullanıcı ve Admin Yönetimi**  
  - Kullanıcı rolleri: **Admin**, **Writer**, **User**.  
  - Admin paneli üzerinden kullanıcı ekleme, silme ve yetki atama.  
  - Rollere göre sayfa ve içerik yönetimi kontrolü:
    - **Admin:** Tüm yönetim haklarına sahip. Kullanıcı ekleme/silme, makale onaylama, kategori yönetimi.  
    - **Writer:** Sadece kendi makalelerini oluşturabilir, düzenleyebilir ve yayın için gönderebilir.  
    - **User:** Sadece blog içeriklerini okuyabilir, yorum yapabilir.  

- ✍️ **Makale Yönetimi (CRUD)**  
  - Makale oluşturma, düzenleme, silme ve yayınlama.  
  - Yayın akışı rollere göre kontrol edilir (Writer → Admin onayı → Yayın).  

- 🏷️ **Kategori ve Etiket Yönetimi**  
  - Makaleleri kategorilere ve etiketlere göre sınıflandırma.  
  - Admin kategori ve etiket ekleyebilir, düzenleyebilir veya silebilir.  

- 🤖 **AI Destekli İçerik Önerileri**  
  - OpenAI API ile otomatik makale önerileri ve içerik üretimi.  
  - Writer’lar öneri alabilir ve içeriklerini hızlıca geliştirebilir.  

- 📱 **Responsive Tasarım**  
  - Masaüstü ve mobil cihazlara uyumlu modern UI.  
  - Dashboard ve içerik sayfaları tüm cihazlarda optimize edilmiş.


### ⚡ Gelişmiş Özellikler
--------------------------------------------------
- 📊 **İstatistikler ve Raporlar**  
  - Admin panelinden blog performansını takip edebilirsiniz:  
    - Makale görüntüleme sayısı  
    - Popüler kategoriler ve etiketler  
    - Writer bazlı içerik performansı  

- 🔐 **Güvenli API Key Yönetimi**  
  - Hassas bilgiler commit edilmeden, çevresel değişkenler üzerinden güvenli bir şekilde yönetilir.  
  - OpenAI API anahtarı ve diğer servis anahtarları güvenli bir şekilde saklanır.  

- 🧩 **Modüler Proje Yapısı**  
  - **Business**, **DataAccess** ve **Entity** katmanları ile temiz ve sürdürülebilir mimari.  
  - Yeni özellik eklemek veya mevcut modülleri yönetmek kolay.  

- 🤖 **AI Destekli Yorum Kontrolü**  
  - Kullanıcı yorumları AI ile analiz edilir.  
  - Toxic veya uygunsuz içerik tespit edilirse kullanıcıya uyarı gösterilir.  
  - Admin panelinde yorum istatistikleri ve raporları takip edilebilir.  

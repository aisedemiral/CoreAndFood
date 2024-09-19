# CoreAndFood
## Kıymetli Murat Yücedağ'ın 100 Derste Asp.Net Core 3.1 MVC Kampı'ndan baz alarak yapmış olduğum Admin Panelli bir e-ticaret site demosu.

NOT:Bu proje örneği geliştirilebilir fakat hala ASP.Net Core altyapısında eksiğim var. Ve ayrıca projeyi kullanırken şu hususta bazı değişiklikler yapmanız gerek:

- Projeyi yerel bir veritabanında kurduğum için Admin Panelini doğrudan kullanamayacağınız gibi projeyi Localhost'ta da çalıştıramazsınız.Bu yüzden "Models" klasörü içerisindeki "Context.cs" dosyasında SQL Server bağlantı stringini size ait olan SQL Server bağlantı stringinize göre değiştirmeniz gerekmektedir.

- Admin Panelinde normal şartlarda Google'ın sütun ve daire dilimi istatistiklerini kullandığım 2 örnek var fakat Admin Paneli'ndeki linkleri yorum satırı olarak dönüştürdüm. Dilerseniz bu verileri de kullanmış oldğum asıl daire dilimi istatikler gibi kullanabilirsiniz.

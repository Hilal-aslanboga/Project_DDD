1- Projeye ba�lamadan �nce Blank Solution olu�turulur.

2- Project_DDD.DomainLayer ad�nda Class Library (.Net Core) t�r�nde proje olu�turulur.
2.1 Entities klas�r� a��l�r. ��ersine Concrete ve Interface klas�rleri a��l�r. Bu klas�r alt�nda projede i�ersinde kullan�lacak Entities ler dizayn edilir.
2.2 Sabitlerimizi tutuca��m�z bir Enums Klas�r� a��l�r.
2.3 Repositories klas�r� a��l�r. Entities CRUD operasyonlar�nda yard�mc� olacak methodlar interfacelerden dizayn edilir.
2.4 UnitOfWork klas�r� a��l�r. Unit of Work desenine dahil edilecek Repository'lerin tipinde �zellikler eklenir.

3- Project_DDD.InfrastructureLayer ad�nda Class Library (.Net Core) t�r�nde proje olu�turulur.
3.1 Mapping klas�r� a��l�r. Projedeki entitiesler burda configure edilir.
3.2 Context klas�r� a��l�r. ��ersine ApplicationDbContext.cs s�n�f� olu�turulur.
3.3 Repositories klas�r� a��l�r.
3.4 UnitOfWork klas�r� a��l�r. Dahil edilicek Repositoryler Singleton deseni ile olu�turulur.

4- Project_DDD.ApplicationLayer ad�nda Class Library(.Net Core) t�r�nde proje olu�turulur.
4.1 Models klas�r� a��l�r. ��ersine DTOlar eklenir.
4.2 Mapper klas�r� a��l�r. ��ersine  DTO, VM ile Domainler match edilir.
4.3 Services klas�r� a��l�r. Burada uygulamada yap�lacak spesifik i�ler ��z�mlenir.
4.4 Validations klas�r� a��l�r. FluentValidation yard�m�yla DTO'lara kurallar koyulur.
4.5 IoC klas�r� a��l�r. Uygulma i�erisinde ba��ml�l��a neden olacak tight couple s�n�flar burada 3rd part IoC Container olan Autofac i�erisinde register edilir.
4.6 Extensions klas�r� a��l�r. Burada statick bir s�n�f i�erisinde Principle yaz�l�r. Login olmu� kullan�c�n�n baz� bilgilerinin yakalamada kullan�lcak methodlar bulundurulur.

5- Project_DDD.PresentationLayer ad�nda Asp .Net Core 3.1 verisoyununda MVC temas�na sahip proje olu�turulur.
5.1 Program.cs i�ersine gelinerek gerekli i�lemler yap�l�r.
5.2 Startup.cs i�ersinde ihtiya� duyulan d�zenlemeler yap�l�r.
5.3 Migrations olu�turulur.
5.4 Gerekli Controller lar a��l�r.
5.5 Gerekli Views ler a��l�r.

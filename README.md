# MyCookbook
 
MyCookbook je web aplikacija za spremanje recepata i planiranja obroka koja se temelji na mikroservisima.

Live web aplikacija je dostupna na adresi: http://my-cookbook.azurewebsites.net

Instalacija projekta na lokalno računalo:

//ASP.Net Core projekt
1. otvoriti MyCookbookAPI projekt u Visual Studiu i napraviti build
2. otvoriti Package Manager Console i izvršiti naredbu 'update-database' za RecipeMicroservice, MealMicroservice i UserMicroservice
3. pokrenuti projekt

//Angular projekt
1. instalirati Node.js (ukoliko već nije)
2. izvršiti naredbu 'npm install -g @angular/cli' (ukoliko Angular već nije instaliran)
3. otvoriti MyCookbookApp u VS Code-u te izvršiti naredbe 'npm install' i 'npm start'

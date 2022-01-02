Requirement:
1. Dotnet Framework 5.0.404 : https://dotnet.microsoft.com/en-us/download/dotnet/5.0
2. Node JS: https://nodejs.org/en/ 
3. Angular 13:
    a. install Node Js dahulu
    b. buka cmd/terminal
    c. masukkan command: npm install -g @angular/cli
    d. tekan enter

Pre-instal:
1. Setelah clone github masuk ke folder "serverside" lalu jalankan perintah: dotnet restore
2. Masuk ke folder "clientapp" lalu jalankan perintah: npm install
3. Buat Database sesuai konfigurasi di "serverside/appsettings.json" bagian ConnectionStrings

Running:
1. Masuk ke folder "serverside" jalankan perintah: dotnet watch run
2. Masuk ke folder "clientapp" jalankan perintah: npm start
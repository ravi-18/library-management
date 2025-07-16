# library-management
Sistem manajemen perpustakaan berbasis .NET, dikembangkan untuk technical test DOT Indonesia.

# 📘 ASP.NET Core Minimal Feature Project

## 🔧 Tech Stack

* **Framework:** ASP.NET Core
* **Language:** C#
* **ORM:** Entity Framework Core
* **Database:** Microsoft SQL Server
* **Cache/Message Broker (opsional):** Redis

---

## 🌟 Project Overview

Ini adalah proyek backend berbasis ASP.NET Core yang mengimplementasikan fitur minimal sebagai berikut:

### ✅ **Authentication & Authorization**

* Menggunakan JWT (JSON Web Token) untuk autentikasi.
* Implementasi role-based authorization:

  * Role pengguna seperti: `Admin`, `User`, `Manager`, dll.
  * Setiap peran memiliki hak akses yang berbeda pada endpoint tertentu.
* Middleware digunakan untuk memverifikasi token dan otorisasi sebelum pengguna mengakses resource.

### ✅ **Database Design**

* Menggunakan Microsoft SQL Server.
* Desain relational database optimal dengan minimal 2 tabel relasi.
* Contoh entitas: `Users`, `Books`, `BorrowTransactions` (dengan relasi antara `Books` dan `BorrowTransactions`).
* Fitur transactional diimplementasikan untuk menjamin konsistensi data saat melakukan perubahan pada dua tabel atau lebih (misalnya saat membuat pesanan yang melibatkan update stok produk dan insert order secara bersamaan).

### ✅ **Integrasi dengan Public API**

* Aplikasi ini terintegrasi dengan salah satu **Public API** sesuai dengan use case, contoh:

  * Integrasi dengan API **Exchange Rate** untuk konversi mata uang saat checkout.
  * Atau API **OpenWeatherMap** untuk informasi cuaca pada lokasi tertentu (bergantung pada use case yang Anda pilih).
* Public API dipanggil menggunakan `HttpClientFactory` dengan konfigurasi retry policy jika diperlukan.

---

## 🚀 Fitur Utama

* [x] Registrasi dan login user
* [x] Role-based access control (RBAC)
* [x] Proteksi endpoint dengan `[Authorize(Roles = "Admin")]`
* [x] Desain database relasional
* [x] Transaksi database (TransactionScope / EF Core Transaction)
* [x] Konsumsi public API eksternal

---

## 🏧 Arsitektur Folder

```bash
├── Controllers/
├── Models/
├── DTOs/
├── Data/
├── Services/
├── Interfaces/
├── Middleware/
├── Migrations/
├── Program.cs
├── appsettings.json
```

---

## 🧪 Cara Menjalankan

1. Clone repositori:

   ```bash
   git clone https://github.com/ravi-18/library-management.git
   cd project-minimal-feature
   ```

2. Atur koneksi database di `appsettings.json`

3. Jalankan migrasi database:

   ```bash
   dotnet ef database update
   ```

4. Jalankan aplikasi:

   ```bash
   dotnet run
   ```

---

## 🔐 Contoh Role Authorization

| Endpoint                 | Role Akses |
| ------------------------ | ---------- |
| `GET /api/Book`         | Admin      |
| `POST /api/Book`        | User       |
| `DELETE /api/Book/{id}` | Admin      |

---

## 🌐 Contoh Integrasi Public API

Contoh penggunaan API kurs mata uang:

```csharp
var response = await _httpClient.GetAsync("https://api.exchangerate-api.com/v4/latest/USD");
var content = await response.Content.ReadAsStringAsync();
// Konversi harga produk ke IDR atau lainnya
```

---

## 📦 Dependency Utama

* `Microsoft.AspNetCore.Authentication.JwtBearer`
* `Microsoft.EntityFrameworkCore.SqlServer`

---

## 📝 Catatan

* Proyek ini disusun dengan memperhatikan praktik clean code dan separation of concerns.
* Setiap fitur dapat dikembangkan lebih lanjut sesuai kebutuhan bisnis.

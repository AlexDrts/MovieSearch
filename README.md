<div align="center">

# 🎬 MovieSearch

**Fullstack movie catalog — React 19 frontend + ASP.NET Core Web API (.NET 10) with a 3-layer architecture**

[![Live Demo](https://img.shields.io/badge/Live%20Demo-Vercel-ff4fa3?style=for-the-badge&logo=vercel&logoColor=white)](https://movie-search-react-chi.vercel.app/)

![.NET](https://img.shields.io/badge/.NET%2010-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![React](https://img.shields.io/badge/React%2019-20232A?style=flat-square&logo=react&logoColor=61DAFB)
![Vite](https://img.shields.io/badge/Vite-646CFF?style=flat-square&logo=vite&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)
[![CI](https://github.com/AlexDrts/MovieSearch/actions/workflows/ci.yml/badge.svg)](https://github.com/AlexDrts/MovieSearch/actions/workflows/ci.yml)

</div>

<img width="100%" alt="photo_2026-10-24_22-19-33" src="https://github.com/user-attachments/assets/b52c8b34-aa37-43cf-b74c-564af59e3a16" />

## ✨ Features

- 📃 **Movie catalog** with posters, genre, year, director and description
- 🔍 **Movie details** page for each film
- ➕ **Create, edit and delete** movies (full CRUD)
- 🖼 **Poster upload** — jpg, png, webp, gif, stored on the server
- ✅ **Server-side validation** — required fields, length limits, release year can't be in the future
- 🌍 **3 languages** — English, Ukrainian, French (auto-detects browser language)
- 🎞 **Seeded with 10 classic films** so the app isn't empty on first run

## 🏗 Architecture

```
MovieSearch/
├── MovieSearch.API/        # Presentation layer — controllers, request models, validation
├── MovieSearch.BLL/        # Business logic — services, DTOs
├── MovieSearch.DAL/        # Data access — EF Core DbContext, Repository + Unit of Work
└── movie-search-react/     # React SPA (Vite, React Router, i18next)
```

- **Repository + Unit of Work** patterns in the data layer
- **DTOs** separate API contracts from database entities
- **Database:** SQL Server when a connection string is set, otherwise **EF Core InMemory** — runs with zero setup

## 📡 API

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/movies` | Get all movies |
| `GET` | `/api/movies/{id}` | Get a movie by id |
| `POST` | `/api/movies` | Create a movie |
| `PUT` | `/api/movies/{id}` | Update a movie |
| `DELETE` | `/api/movies/{id}` | Delete a movie |
| `POST` | `/api/movies/{id}/poster` | Upload a poster (multipart/form-data) |

## 🚀 Getting started

### Backend

```bash
cd MovieSearch.API
dotnet run
# API: http://localhost:5074/api/movies
```

To use SQL Server, add a connection string to `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=...;Database=MovieSearch;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### Frontend

```bash
cd movie-search-react
cp .env.example .env     # VITE_API_URL=http://localhost:5074
npm install
npm run dev
```

### Docker (API)

```bash
docker build -t moviesearch-api .
docker run -p 8080:8080 moviesearch-api
```

## 🗺 Roadmap

- [ ] Search and filtering by title, genre and year
- [ ] Pagination
- [ ] Authentication for editing
- [ ] Unit tests for the BLL layer

---

<div align="center">

Made by [Alex](https://github.com/AlexDrts) 😈

</div>

# UrlShortner

A modern URL shortener built with .NET 9 and PostgreSQL, containerized using Docker for easy local development.

---

## 🚀 Features

- Shorten long URLs with ease
- Track URL statistics
- Built with ASP.NET Core (.NET 9)
- PostgreSQL database
- Fully containerized with Docker Compose

---

## 🛠️ Getting Started

### 1. Clone the Repository

### 2. Environment Setup

Create a `.env` file in the root directory (already present in this repo). Ensure it contains:

- `POSTGRES_DB`: Name of the PostgreSQL database
- `POSTGRES_USER`: Database username
- `POSTGRES_PASSWORD`: Database password

> **Tip:** You can change these values as needed, but make sure to update them in `compose.yml` and your app settings if you do.

---

### 3. Running with Docker

Build and start the services using Docker Compose:

- The web app will be available at: [http://localhost:5000](http://localhost:5000)
- PostgreSQL will be running on port `5432`

To stop the services:

---

## 📦 Project Structure

- `compose.yml` — Docker Compose configuration
- `dockerfile` — Web app Docker build instructions
- `db-init/init.sql` — Database initialization script
- `.env` — Environment variables

---

## 📖 Learn More About Docker

Read this blog for a deeper dive into Docker and containerization:  
[https://medium.com/@sparshpathak2002](https://medium.com/@sparshpathak2002)

---

## 🤝 Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

---

## 📝 License

This project is licensed under the MIT License.
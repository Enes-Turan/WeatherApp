# WeatherApp

A clean and lightweight **C# (.NET)** console application that provides real-time weather information using the **OpenWeatherMap API**.  
Designed with best practices such as configuration management, error handling, and character normalization.

---

## 🌤️ Overview

WeatherApp allows users to retrieve live weather data for any city worldwide.  
The project keeps API keys outside the codebase using `appsettings.json` and handles common API/network errors gracefully.

---

## ✨ Features

- Live weather data (temperature, feels-like, humidity, conditions)
- Turkish character normalization for user input
- API key stored securely in configuration (not in source files)
- Meaningful error messages for:
  - Invalid city names  
  - Invalid or missing API keys  
  - Network issues  
  - Unexpected API responses  
- Clean separation of logic (`Program`, `WeatherService`, response models)

---

## 🛠️ Technologies Used

- **C# (.NET 7)**
- **HttpClient** for HTTP requests  
- **System.Text.Json** for JSON parsing  
- **Microsoft.Extensions.Configuration** for config management  

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/WeatherApp.git
cd WeatherApp

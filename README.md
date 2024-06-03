# PokemonApp

## Overview

Pokemon have magically come to life and are running rampant across the globe! Park Rangers
have collected extensive data on each Pokemon and need a way to present and share it with
everyone.
We build a web application that allows users to browse through the pokemon and view
details on each. 

This app use a React app that calls into a C# API.

This project is a full-stack application consisting of a .NET Web API backend and a React frontend. The .NET Web API provides a RESTful service, and the React client consumes these services to create a dynamic web application.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Backend Setup](#backend-setup)
- [Frontend Setup](#frontend-setup)

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js (LTS version)](https://nodejs.org/)
- [Visual Studio Code](https://code.visualstudio.com/) or any other code editor
- [Git](https://git-scm.com/)

## Getting Started

Follow these steps to get the project up and running on your local machine.

### Backend Setup

1. **Clone the repository**

    ```bash
    git clone https://github.com/alex100915/PokemonApp.git
    cd PokemonApp
    ```

2. **Navigate to the API directory**

    ```bash
    cd PokemonApp.API
    ```

3. **Restore dependencies**

    ```bash
    dotnet restore
    ```

4. **Run the .NET Web API**

    ```bash
    dotnet run
    ```

    The API will be available at `https://localhost:7321`.

### Frontend Setup

1. **Navigate to the client-app directory**

    ```bash
    cd ../client-app
    ```

2. **Install dependencies**

    ```bash
    npm install
    ```

3. **Start the React application**

    ```bash
    npm start
    ```

    The React app will be available at `http://localhost:3000`.
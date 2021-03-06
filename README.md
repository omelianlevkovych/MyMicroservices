<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="assets/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">MyMicroservices</h3>

  <p align="center">
    Simple microservices via .Net technologies!
    <br />
    <a href="https://github.com/omelianlevkovych/MyMicroservices"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/omelianlevkovych/MyMicroservices">View Demo</a>
    ·
    <a href="https://github.com/omelianlevkovych/MyMicroservices/issues">Report Bug</a>
    ·
    <a href="https://github.com/omelianlevkovych/MyMicroservices/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Build and Test</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## Introduction

[![Product Name Screen Shot][product-screenshot]](https://example.com)

The overall architecture design and technology stack is shown in the following picture:

![ildasm](https://github.com/omelianlevkovych/MyMicroservices/blob/main/assets/BigPicture.png)

The business domain of the application is e-commerce.
The core functionality is based on four microservices (APIs): Catalog, Basket, Ordering and Discount. 

A list of commonly used resources that I find helpful are listed in the acknowledgements.

### Built With

Each microservice is based on .Net technology stack using REST API architecture principles.

For containerezation Docker and Docker Compose is used.

Except from ASP.NET Core Web API app (.NET version 5) every microservice contains other technologies.

The Catalog microservice includes:
- **MongoDb**
- Clean code, repository pattern, open-api spec, etc


The Basket microservice includes:
- **Redis db**
- It consumes Discount **Grpc** Service for sync communication in order to calculate the product final price
- It publishes to BasketCheckout Queue using **MassTransit** and **RabbitMQ**


The Discount microservice includes:
- ASP.NET **Grpc** Service app
- High performant inter-service gRPC communication with Basket microservice
- **Dapper** for micro-orm implementation
- **PostgreSQL db**


The Ordering microservice includes:
- **DDD, CQRS** approaches
- CQRS with using **MediatR, FluentValidation and AutoMapper packages**
- Consuming **RabbitMQ** BasketCheckout queue with using **MassTransit-RabbitMQ** config
- **SqlServer db**
- **Entity Framework Core** ORM

The API Gateway Ocelot:
- Implement **API Gateways with Ocelot**
- Microservices/containers to reroute through the API Gateway
- Run multiple different **API Gateway/BFF** container types
- The Gateway **aggregation pattern** in Shopping.Aggregation

WebUI ShoppingApp microservice includes:
- ASP.NET Core Web App with Bootstrap 4 and Razor template
- Call **Ocelot APIs with HttpClientFactory** and **Polly**

Microservices Cross-Cutting Implementations:
- Implementing **Centralized Distributed Logging with Elastic Stack (ELK); Leasticsearch, Logstash, Kibana and SeriLog**
- Use the **HealthChecks** featrue in back-end ASP.NET
- Using **Watchdog** in separate service that can watch health and load across services, and report health

The microservices resilience implementations:
- Making microservices more resilent by using **IHttpClientFactory**
- Implement **Retry and Circuit Breaker patterns** with IHttpClientFactory and **Polly policies**

The containers:
- Docker is used
- For container lightweight managment through GUI the **Portainer** is used
- The **pgAdmin PostgreSQL** Tools


This section should list any major frameworks that you built your project using. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.
* [Bootstrap](https://getbootstrap.com)
* [JQuery](https://jquery.com)
* [Laravel](https://laravel.com)



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```JS
   const API_KEY = 'ENTER YOUR API';
   ```



<!-- USAGE EXAMPLES -->
## Build and Test

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_



<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a list of proposed features (and known issues).



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Your Name - [@your_twitter](https://twitter.com/your_username) - email@example.com

Project Link: [https://github.com/your_username/repo_name](https://github.com/your_username/repo_name)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
Readme Template
* [GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet)
* [Img Shields](https://shields.io)
* [Choose an Open Source License](https://choosealicense.com)
* [GitHub Pages](https://pages.github.com)
* [Animate.css](https://daneden.github.io/animate.css)
* [Loaders.css](https://connoratherton.com/loaders)

.Net Projects

* [.Net Architecture](https://github.com/dotnet-architecture/eShopOnContainers)
* [.Net Run Project](https://github.com/aspnetrun/run-aspnetcore-microservices)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/omelianlevkovych/MyMicroservices.svg?style=for-the-badge
[contributors-url]: https://github.com/omelianlevkovych/MyMicroservices/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/omelianlevkovych/MyMicroservices.svg?style=for-the-badge
[forks-url]: https://github.com/omelianlevkovych/MyMicroservices/network/members
[stars-shield]: https://img.shields.io/github/stars/omelianlevkovych/MyMicroservices.svg?style=for-the-badge
[stars-url]: https://github.com/omelianlevkovych/MyMicroservices/stargazers
[issues-shield]: https://img.shields.io/github/issues/omelianlevkovych/MyMicroservices.svg?style=for-the-badge
[issues-url]: https://github.com/omelianlevkovych/MyMicroservices/issues
[license-shield]: https://img.shields.io/github/license/omelianlevkovych/MyMicroservices.svg?style=for-the-badge
[license-url]: https://github.com/omelianlevkovych/MyMicroservices/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://404.lol
[product-screenshot]: assets/screenshot.png

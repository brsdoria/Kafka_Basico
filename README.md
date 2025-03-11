# Kafka

Considarado um message broker de alto desempenho, escalável e resiliente, que gerencia a transmissão de mensagens entre sistemas. 
Ele permite a publicação e consumo de mensagens, com armazenamento durável e eficiente. É utilizado em sistemas que exigem processamento de eventos em tempo real, 
integração entre microserviços e monitoramento de dados, sendo uma solução robusta para ambientes de alta demanda.

## 🛠️ Construído com 

* [Visual Studio Code](https://code.visualstudio.com/) - Editor de código-fonte leve e de código aberto da Microsoft, que oferece uma experiência de desenvolvimento poderosa e altamente personalizável, embora seja mais simples que o Visual Studio.

## 📚 Principais Bibliotecas, Frameworks e Comandos do NuGet Utilizados

* [net9.0](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-9/overview) - Versão da plataforma de desenvolvimento .NET, que é de código aberto e multiplataforma, desenvolvida pela Microsoft.
```
dotnet add package Microsoft.NET.Sdk.WebAssembly.Pack --version 9.0.0
```
* [Confluent.Kafka]() -  Biblioteca cliente para a plataforma Apache Kafka para fornecer uma interface de alta performance e fácil de usar para interagir com o Kafka a partir de aplicações .NET (C#).
```
dotnet add package Confluent.Kafka
```
* [Confluent.SchemaRegistry.Serdes.Avro]() - Biblioteca do Confluent, parte da plataforma Apache Kafka, que oferece suporte ao uso de schemas Avro (um formato de serialização de dados) para codificar e decodificar mensagens em um sistema Kafka.
```
dotnet add package Confluent.SchemaRegistry.Serdes.Avro
```
## 🚧 Descrição da Estrutura do Projeto

A estrutura do projeto segundo a imagem abaixo é composta da seguinte forma:

![EstruturaDoProjeto](screenshots/estrutura.png)

## ⚠️ Atenção

Destinado exclusivamente para fins de estudo.

---
⌨️ por [Byron Doria](https://gist.github.com/lohhans) 😊

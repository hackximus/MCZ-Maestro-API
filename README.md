# MCZ-Maestro-API
MCZ-Maestro Oven API
Version 1.0.0

The problem is that the oven does not have a public interface and therefore cannot be used with systems such as Homee, Openhab, Beckhoff etc.
The idea was to program an interface with which all common systems can communicate. It was important to me that this software should work platform-independently, e.g. on a Raspberry Pi. That's why I decided to use .NET Core.

## Getting Started

The MCZ-Maestro-API is a Visual Studio 2019 Project.
You can run it on:

  - Docker
  - Linux
  - Windows
  
The only thing that should be noted is that two network interfaces should be available because the oven operates its own hotspot and it only communicates with the software via this network connection.
  
## Usage

First you can use Swagger to test the API. 
> https://localhost:port/swagger/index.html

To send a command to the furnace, an HTTP PUT request can be sent. Here is an example of changing the setpoint to 23°C. 
> https://localhost:port/api/Maestro/42?value=23

The number 42 is the ID. You can get all the ID's with an HTTP GET request.
> https://localhost:port/api/Maestro

*Some commands can take up to 10 seconds to process.*

A good instruction to Setup .NET Core 3.0 Runtime and SDK on Raspberry Pi 4

> https://edi.wang/post/2019/9/29/setup-net-core-30-runtime-and-sdk-on-raspberry-pi-4


## Last words
I'm so sorry for my english and this is my first readme on github. Have mercy on me :innocent:

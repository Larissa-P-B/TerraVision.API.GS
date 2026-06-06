## 👨‍💻 Integrantes

* Larissa Pereira Biusse - RM 564068
* Thamiris Almeida - RM 559155
* Werbeth Nunes - RM 559067

# 🌎 TerraVision API

API REST desenvolvida em **.NET 8** para monitoramento climático inteligente, integrada à **OpenWeather API** e persistência de dados em **MySQL**.

O sistema realiza consultas meteorológicas em tempo real, analisa riscos ambientais, mantém histórico das leituras climáticas e simula um ambiente de monitoramento espacial utilizando satélites e sensores climáticos.

---

# 📌 Objetivo do Projeto

O TerraVision foi desenvolvido para auxiliar no monitoramento e análise de eventos climáticos extremos, permitindo identificar possíveis riscos ambientais e apoiar ações preventivas.

O sistema monitora condições meteorológicas em diversas cidades e classifica automaticamente situações de risco como:

- 🌪 Tornados
- 💨 Vendavais
- ⛈ Tempestades severas
- 🌡 Ondas de calor
- 🌊 Alagamentos
- 🏜 Secas extremas
- ⚠ Instabilidades climáticas

---

# 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Swagger / OpenAPI
- Dependency Injection
- HttpClient Factory
- OpenWeather API
- LINQ
- ILogger
- Middleware Global de Exceções

---

# 🏗 Arquitetura da Aplicação

```text
TerraVision.API

├── Controllers
│   ├── ClimateController.cs
│   ├── AlertController.cs
│   └── DeviceController.cs
│
├── Services
│   ├── Interfaces
│   │   ├── IClimateService.cs
│   │   └── IAlertService.cs
│   │
│   ├── ClimateService.cs
│   ├── AlertService.cs
│   ├── DeviceSimulationService.cs
│   └── RiskAnalysisService.cs
│
├── Clients
│   └── OpenWeatherClient.cs
│
├── Models
│   ├── Entities
│   │   ├── ClimateReading.cs
│   │   ├── Alert.cs
│   │   ├── Sensor.cs
│   │   ├── Satellite.cs
│   │   └── MonitoringDevice.cs
│   │
│   ├── DTOs
│   └── Structs
│       └── GeoCoordinate.cs
│
├── Data
│   └── TerraVisionDbContext.cs
│
├── Repositories
│
├── Middleware
│
├── Exceptions
│
├── Program.cs
│
└── appsettings.json
```

---

# 🧠 Conceitos de Programação Orientada a Objetos

## Abstração

A aplicação utiliza a classe abstrata `MonitoringDevice` para representar dispositivos de monitoramento climático.

```csharp
public abstract class MonitoringDevice
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public abstract string GetDeviceType();
}
```

---

## Herança

As classes `Sensor` e `Satellite` herdam da classe abstrata `MonitoringDevice`.

```csharp
public class Sensor : MonitoringDevice
```

```csharp
public class Satellite : MonitoringDevice
```

---

## Polimorfismo

Cada dispositivo implementa seu próprio comportamento através do método:

```csharp
GetDeviceType()
```

Exemplo:

```csharp
sensor.GetDeviceType();
```

Retorna:

```text
Sensor Climático
```

```csharp
satellite.GetDeviceType();
```

Retorna:

```text
Satélite Meteorológico
```

---

## Struct

Foi utilizada uma estrutura (`struct`) para representar coordenadas geográficas.

```csharp
public struct GeoCoordinate
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
```

---

## Partial Class

A entidade principal de persistência foi implementada utilizando Partial Class.

```csharp
public partial class ClimateReading
{
}
```

---

## Injeção de Dependência

Toda a aplicação utiliza Dependency Injection nativa do ASP.NET Core.

```csharp
builder.Services.AddScoped<IClimateService, ClimateService>();
```

---

# 🌦 Integração com OpenWeather

A API consome dados meteorológicos em tempo real através da OpenWeather API.

Site oficial:

https://openweathermap.org/

Dados coletados:

- Temperatura
- Umidade
- Pressão atmosférica
- Velocidade do vento
- Condições climáticas

---

# ⚙️ Configuração do Banco de Dados

## Criar Banco

Executar no MySQL:

```sql
CREATE DATABASE terravision;
```

---

## Configuração do appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=terravision;user=root;password=1234"
  },

  "OpenWeather": {
    "ApiKey": "SUA_API_KEY"
  }
}
```

---

# ▶️ Como Executar o Projeto

## 1. Clonar Repositório

```bash
git clone https://github.com/SEU-USUARIO/TerraVision.API.GS.git
```

---

## 2. Entrar na Pasta

```bash
cd TerraVision.API.GS
```

---

## 3. Restaurar Dependências

```bash
dotnet restore
```

---

## 4. Criar Migration

```bash
Add-Migration InitialCreate
```

---

## 5. Atualizar Banco

```bash
Update-Database
```

---

## 6. Executar Aplicação

```bash
dotnet run
```

---

# 📡 Swagger

Após iniciar o projeto:

```text
https://localhost:7105/swagger
```

ou

```text
https://localhost:7105/swagger/index.html
```

---

# 🌤 Endpoints Climáticos

## Buscar clima atual

```http
GET /api/climate/{city}
```

### Exemplo

```http
GET /api/climate/SaoPaulo
```

---

## Histórico Climático

```http
GET /api/climate/history
```

---

## Buscar Histórico por ID

```http
GET /api/climate/history/{id}
```

---

## Estatísticas Climáticas

```http
GET /api/climate/stats
```

### Exemplo de retorno

```json
{
  "totalReadings": 57,
  "normalReadings": 32,
  "highRiskReadings": 18,
  "criticalReadings": 7,
  "lastReadingDate": "2026-06-04T17:30:00"
}
```

---

# 🚨 Alertas Climáticos

## Listar Alertas

```http
GET /api/alerts
```

---

## Listar Alertas Críticos

```http
GET /api/alerts/critical
```

### Exemplo

```json
[
  {
    "alertType": "TORNADO",
    "severity": "CRITICA",
    "description": "Possível formação de tornado"
  }
]
```

---

# 🛰 Simulação de Monitoramento

O sistema possui uma simulação de monitoramento espacial e terrestre.

Elementos simulados:

- Satélites meteorológicos
- Sensores climáticos
- Coordenadas geográficas
- Alertas climáticos

---

## Dispositivos Monitorados

```http
GET /api/devices
```

Exemplo:

```json
[
  {
    "name": "GOES-16",
    "deviceType": "Satélite Meteorológico"
  },
  {
    "name": "Sensor Manaus",
    "deviceType": "Sensor Climático"
  }
]
```

---

## Simulação de Evento Climático

```http
GET /api/devices/simulation
```

### Exemplo

```json
{
  "satelliteName": "NOAA-20",
  "sensorName": "Sensor Recife",
  "region": "Nordeste",
  "latitude": -8.0476,
  "longitude": -34.8770,
  "deviceType": "Satélite Meteorológico",
  "alertType": "TEMPESTADE SEVERA",
  "severity": "ALTA",
  "detectionTime": "2026-06-04T17:20:00"
}
```

Cada chamada gera um cenário aleatório diferente.

---

# 📊 Regras de Análise de Risco

O serviço `RiskAnalysisService` realiza análise automática dos dados climáticos.

| Condição | Resultado |
|-----------|-----------|
| Vento forte | VENDAVAL |
| Temperatura extrema | ONDA DE CALOR |
| Pressão muito baixa | TEMPESTADE SEVERA |
| Condições críticas combinadas | TORNADO |
| Situação estável | NORMAL |

---

# 🛡 Tratamento Global de Exceções

A aplicação possui Middleware Global para captura e tratamento centralizado de erros.

Exemplos:

- GUID inválido
- Cidade inexistente
- Registro não encontrado
- Falha na API OpenWeather
- Erros internos do sistema

Exemplo de resposta:

```json
{
  "message": "Registro não encontrado."
}
```

---

# 📝 Logs da Aplicação

A API registra eventos importantes utilizando `ILogger`.

Exemplos:

```text
Consulta realizada para cidade São Paulo
```

```text
Risco identificado: VENDAVAL | Severidade: ALTA
```

Esses logs auxiliam no monitoramento e auditoria da aplicação.

---

# 🔄 Fluxo da Aplicação

```text
Usuário
   │
   ▼
ClimateController
   │
   ▼
ClimateService
   │
   ▼
OpenWeatherClient
   │
   ▼
OpenWeather API
   │
   ▼
RiskAnalysisService
   │
   ▼
ClimateRepository
   │
   ▼
MySQL

──────────────────────────────

DeviceController
   │
   ▼
DeviceSimulationService
   │
   ├── Satellite
   ├── Sensor
   ├── GeoCoordinate
   └── Alert
```

---

# 📸 Evidências de Execução

Durante os testes foram validados:

- Consulta de clima em tempo real
- <img width="1778" height="675" alt="image" src="https://github.com/user-attachments/assets/fdc755e4-e715-46d8-8fd2-6f918d375b67" />

- Persistência no MySQL
- <img width="1023" height="231" alt="image" src="https://github.com/user-attachments/assets/5379f75b-f4bd-4749-96b6-b2bac1dece70" />

- Histórico climático
- <img width="1772" height="866" alt="image" src="https://github.com/user-attachments/assets/29475b38-529e-49d3-9930-85080af881b2" />

- Estatísticas climáticas
- <img width="1778" height="622" alt="image" src="https://github.com/user-attachments/assets/469de5f2-1de4-4608-a280-23025d931740" />

- Alertas climáticos
- <img width="1779" height="833" alt="image" src="https://github.com/user-attachments/assets/be844bef-4231-4354-91a9-787fb76090d5" />

- Simulação de dispositivos
- <img width="1777" height="704" alt="image" src="https://github.com/user-attachments/assets/eba1da44-5418-475f-9ff7-c9823a1c83ce" />

- Middleware global
- <img width="1768" height="455" alt="image" src="https://github.com/user-attachments/assets/0a45b00c-51a7-426b-a0c1-19bd80247b38" />

- <img width="1769" height="441" alt="image" src="https://github.com/user-attachments/assets/9b504ae1-1758-44be-9d68-786c17666554" />


- Logs da aplicação
- <img width="1457" height="378" alt="image" src="https://github.com/user-attachments/assets/0409e313-0169-4c39-be1b-846768b81257" />

- Swagger/OpenAPI
- <img width="1467" height="821" alt="image" src="https://github.com/user-attachments/assets/f82560a9-6379-4ff0-a019-910de734051b" />


---

# 👨‍💻 Desenvolvido para Global Solution

Projeto acadêmico desenvolvido utilizando conceitos de:

- Programação Orientada a Objetos
- Arquitetura em Camadas
- APIs REST
- Persistência de Dados
- Integração com Serviços Externos
- Boas Práticas em ASP.NET Core

O objetivo foi demonstrar uma solução tecnológica para monitoramento climático inteligente, utilizando recursos modernos da plataforma .NET e integração com dados meteorológicos em tempo real.

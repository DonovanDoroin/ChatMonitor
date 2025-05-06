# ChatMonitor

This project is a developer evaluation submission for the position of Game Engine Developer III/IV. It demonstrates architectural judgment, MVVM best practices, and familiarity with the .NET stack—centered around real-time data handling using WPF, gRPC, MediatR, and xUnit.

## 📦 Solution Structure

```
ChatMonitor.sln
├── WpfClient       # WPF app frontend using MVVM and MediatR
├── GrpcServer      # Simulated gRPC server that pushes messages
├── Tests           # Unit tests using xUnit and FluentAssertions
```

---

## 🧠 Project Goal

Create a small internal tool that:
- Streams real-time messages from a gRPC backend
- Uses MediatR to route messages in the frontend
- Displays only messages that contain the word **"test"** in the WPF UI

---

## ⚙️ Technologies Used

- .NET 8.0
- WPF (.NET)
- MVVM with `CommunityToolkit.Mvvm`
- gRPC & Protocol Buffers
- MediatR
- Microsoft.Extensions.DependencyInjection
- xUnit
- FluentAssertions
- Moq (for mocking in tests)

---

## 🛠️ Features

### ✅ Backend (`GrpcServer`)
- Defines a `InformationMessage` Protobuf message with:
  - `Id`, `From`, `To`, `Text`, `Timestamp`
- Simulates a gRPC server that periodically pushes messages
- Uses `Grpc.AspNetCore` and `Google.Protobuf`

### ✅ Frontend (`WpfClient`)
- MVVM architecture with MediatR integration
- UI (`InformationView.xaml`) includes:
  - `DataGrid` to show filtered messages
  - Button to start listening to the gRPC stream
- Filters and displays only messages that contain the word `"test"` (case-insensitive)

### ✅ Tests (`Tests`)
- Tests frontend message filtering logic
- Uses:
  - xUnit
  - FluentAssertions
  - Mocked/fake gRPC message inputs

---

## ▶️ How to Run

1. Open `ChatMonitor.sln` in **Visual Studio 2022**.
2. Set **GrpcServer** as startup project and run it.
3. Then set **WpfClient** as startup project and run it.
4. Click **"Start Listening"** to begin receiving and filtering messages.

> ⚠️ Make sure both services run on compatible ports (e.g., `https://localhost:7065`).

---

## 🧪 How to Test

1. Right-click on the `Tests` project
2. Run all tests using **Test Explorer**

Test coverage includes:
- MediatR handler filters messages properly
- Messages without `"test"` are ignored

---

## 📌 Design Considerations

- **MediatR decouples** gRPC reception from message processing logic
- **Dependency Injection** manages component lifetimes and improves testability
- **MVVM structure** cleanly separates UI logic from business logic
- **Async streaming** from gRPC supports future scalability for real-time data

---

## 📁 Deliverable Notes

- This repository contains all source code and test cases
- Built with a 4-hour delivery window in mind, focusing on clarity and correctness
- Includes clean architectural boundaries and readable code

---

## 🧑‍💻 Author
Donovan Paul Doroin
This test was completed as part of a technical assessment. If you have any questions or need clarifications, feel free to reach out.
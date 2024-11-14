#  . NET project 


---
## Connection String

```
Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True
```
- **Create newapi **
  ```bash
  dotnet webapi -o api
  ```

- **Restore Dependencies**
  ```bash
  dotnet restore
  ```

- **Build Project**
  ```bash
  dotnet build
  ```

- **Run Project**
  ```bash
  dotnet run
  ```

- **Clean Project**
  ```bash
  dotnet clean
  ```

- **Publish Project**
  ```bash
  dotnet publish -c Release -o ./publish
  ```

- **Run Tests**
  ```bash
  dotnet test
  ```

- **Add Package**
  ```bash
  dotnet add package <PACKAGE_NAME>
  ```

- **List Packages**
  ```bash
  dotnet list package
  ```

- **Remove Package**
  ```bash
  dotnet remove package <PACKAGE_NAME>
  ```


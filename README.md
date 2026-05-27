# Advanced programming — coursework archive

Erasmus / advanced programming module deliverables: small **C# / .NET** solutions and WinForms-style desktop exercises grouped by lab folder (e.g. `Lab 7` with a `MageGuildApp` sample). Each directory is self-contained — open the `.sln` or `.csproj` in **Visual Studio** / **Rider** with the matching **.NET SDK** (see project file `TargetFramework`).

### Structure

```
Lab <n>/
  └── src/
        ├── *_Library/       # reusable class library layer
        └── *_App/           # executable / WinForms front-end (where applicable)
```

### Türkçe

İleri düzey programlama dersi **laboratuvar ve ödev arşivi**. Klasörler ders bloklarına göre ayrılmıştır; çoğu örnek **C#**, **class library + masaüstü uygulama** kalıbını izler. Derlemek için ilgili klasördeki `.csproj` veya `.sln` dosyasını açıp README’si olmayan alt klasörlerde doğrudan projeyi incelemeniz gerekir.

> Not: Bazı klasörlerde `bin/` ve `obj/` yapıları bulunabilir; yeni ortamda temiz bir build için gereksiz çıktılar silinebilir (`.gitignore` önerilir).

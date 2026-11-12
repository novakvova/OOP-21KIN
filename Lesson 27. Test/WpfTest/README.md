## Налаштування Claude Code у проект
```
irm https://claude.ai/install.ps1 | iex
Test-Path "$env:USERPROFILE\.local\bin\claude.exe"
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";$env:USERPROFILE\.local\bin", "User")

claude --version

claude
/init
Проаналізуй структуру проєкту, технології,
залежності та основні архітектурні рішення та запиши у spec.md

Додай у CLAUDE.md, додай правила кодування, архітектури та тестування.

/cost

/model

claude --resume 472fe80f-fed6-4dea-a6f5-56534527b19d
```
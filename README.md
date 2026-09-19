# Simple Inventory Management System

A console application for adding, viewing, editing, deleting, and searching products.

## Run

```bash
dotnet run
```

Product names are trimmed, compared case-insensitively, and must be unique. Prices and quantities must be non-negative. Prices use the current system culture and are stored as `decimal` values.
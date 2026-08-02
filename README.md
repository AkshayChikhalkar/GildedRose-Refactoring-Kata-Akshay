# Gilded Rose Refactoring Kata

My C# / xUnit solution. I locked in the existing behaviour with tests,
then pulled the nested `UpdateQuality` logic into per-item updater
classes. Conjured items are included too.

## Requirements

- .NET 8 SDK

## Build / test / run

```bash
dotnet build
dotnet test
dotnet run --project GildedRose -- 10
```

## Design

`GildedRose` picks an updater via `ItemUpdaterFactory` (normal, Aged
Brie, backstage, Sulfuras, Conjured). Shared 0–50 / floor-at-0 quality
rules live in `ItemQuality`.

Names starting with `Conjured` (case-sensitive) degrade twice as fast:
−2 before sell-by, −4 after.

## Assumptions

- Left `Item` and the items collection as-is
- Quality stays in 0–50 for non-legendary items during updates
- Sulfuras never changes
- `"Conjured"` prefix match is case-sensitive
- Invalid starting quality (e.g. 70) isn't clamped on entry — limits apply on update only

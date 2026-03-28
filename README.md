# SimpleCSVEditorByWPF

WPF と .NET 9.0 (C#) で開発された、シンプルで使いやすい CSV ファイルエディタです。

## 概要

このアプリケーションは、CSVファイルの読み込みと表示、およびデータ編集を目的としています。
MVVMアーキテクチャを採用しており、内部的なCSV処理にはパフォーマンスと柔軟性に優れた `CsvHelper` ライブラリを使用しています。

## 主な機能

- **CSVファイルの読み込み**: ローカルのCSVファイルを選択して読み込み、画面上に一覧表示します。
- **データ編集機能**: 読み込んだデータに対して、セルの内容を直接編集することができます。

## 動作環境

本アプリケーションを実行・ビルドするには以下の環境が必要です。

- **OS**: Windows
- **ランタイム**: .NET 9.0 Desktop Runtime (または .NET 9.0 SDK)

## 採用技術・ライブラリ

- **フレームワーク**: WPF (Windows Presentation Foundation), .NET 9.0
- **アーキテクチャ**: MVVMパターン
- **主要パッケージ (NuGet)**:
  - `CommunityToolkit.Mvvm` (v8.4.2)
  - `CsvHelper` (v33.1.0)
  - `Microsoft.Xaml.Behaviors.Wpf` (v1.1.142)

## ライセンス

本プロジェクトは [LICENSE](LICENSE) ファイルに記載されているライセンスのもとで公開されています。

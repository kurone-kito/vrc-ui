# ![black.kit.vrcui: 非公式の VRChat 風 uGUI テーマ](https://kurone-kito.github.io/vrc-ui/banner.png)

Language: [🇬🇧](https://github.com/kurone-kito/vrc-ui/blob/main/README.md) | **🇯🇵**

VRChatには「ワールド独自のUIを覚える」ストレスがつきものです。

ワールドごとにバラバラな UI が原因で、迷子になるプレイヤーさんを助けたい……
と、長らくの間考えていました。

もしワールド内で VRChat 標準の UI と同じものを自在に操ることがができるなら、
プレイヤーさんやクリエイターさんは「操作方法を覚える・覚えていただく」
ことに悩むより「ワールドを楽しむ」ことに集中できるでしょう！

この「VRCUI」はそんな製作者さんのために生まれた、VRChat アセットです。

## 🛠 推奨環境

このパッケージは **Unity 2022.3** 以降での利用を想定しています。
[VRChat Creator Companion](https://docs.vrchat.com/docs/creator-companion)
と VPM を利用してインストールすることを推奨します。

## 💡 特徴

- ボタン
- カード
- ドロップダウン
- スクロールバー / スライダー
- スライドショー
- トグル
- 他多数！

## ▶ 使い方

### 1. VRChat Creator Companion (VCC) でレジストリをインポート

**[VPM カタログページ](https://kurone-kito.github.io/vpm/)** にアクセスし、
**Add to VCC** ボタンをクリックします。

### 2. パッケージをプロジェクトにインポート

1. VCC で "Manage Project" ボタンをクリックします。
2. "black.kit.vrcui" パッケージを見つけ、
   "(+) Add package" ボタンをクリックします。

### 3. パッケージを使用し、楽しんでください :D

1. `Packages/black.kit.vrcui/Runtime/Prefabs` フォルダーを開きます。
2. 必要なプレハブを Canvas にドラッグ＆ドロップします。プレハブは
   *Atoms*、*Molecules*、*Organisms* の階層に分類されています。
3. これらのプレハブに付属するスクリプトは、独自のオブジェクトにも
   アタッチできます。

#### 利用例

- **Fps** – `Organisms/Status/Fps.prefab` を配置すると FPS 表示が追加されます。
  `Fps` コンポーネントが一定間隔でテキストを更新します。
- **Progress** – `Organisms/Status/Progress.prefab` を利用し、UdonSharp から
  `Value` プロパティを変更して進捗バーを更新できます。

(今後ドキュメントを追加予定)

## 依存関係

VCC を介してプロジェクトを使用する場合、
以下の依存関係が自動的にインポートされます:

- [VRC Icons (black.kit.launchpadicon)](https://github.com/kurone-kito/launchpad-icons)
- [UdonSharp Toybox (black.kit.toybox)](https://github.com/kurone-kito/udonsharp-toybox)

## 貢献

このリポジトリへの貢献を歓迎します！詳細については、
[CONTRIBUTING.md](https://github.com/kurone-kito/vrc-ui/blob/main/.github/CONTRIBUTING.ja.md)
を参照してください。

## ライセンス

このプロジェクトは以下のオプションでデュアルライセンスです:

- [MIT License](https://opensource.org/licenses/MIT) (既定)
- [Creative Commons CC BY 4.0](https://creativecommons.org/licenses/by/4.0/)

**既定ライセンスは MIT License です**。あなたのプロジェクトにおいて、
任意の方法でオプトインすることで、CC BY 4.0 ライセンスを適用可能です。

このライセンスは、このライブラリが CC BY-NC 4.0 ライセンスで配布されていた、
2025 年 4 月以前の名残であり、互換性のために残しています。

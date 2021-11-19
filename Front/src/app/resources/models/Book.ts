export class Book {
  id: String;
  title: String;
  url: String;
  pageRankPonctuation: number;

  constructor(id: String, title: String, url: String, pageRankPonctuation: number) {
    this.id = id;
    this.title = title;
    this.url = url;
    this.pageRankPonctuation = pageRankPonctuation;
  }
}
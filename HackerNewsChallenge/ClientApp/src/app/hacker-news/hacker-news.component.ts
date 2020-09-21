import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-hacker-news',
  templateUrl: './hacker-news.component.html',
  styleUrls: ['./hacker-news.component.css']
})
export class HackerNewsComponent {
  public filteredStories: StoryList[];
  public stories: StoryList[];
  public searchValues = '';
  p: number = 1;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>(baseUrl + 'api/HackerNews/getStoryList').subscribe(result => {
      let filterResponse = result.filter( x => {
        return x !== null
      })
      this.stories = filterResponse;
      this.filteredStories = filterResponse;
    }, error => console.error(error));
  }

  openWindow(e) {
    console.log(e);
    if (e.url) {
      window.open(e.url)
    }
  }

  searchStories(value: string) {
    this.searchValues = value;
    this.filteredStories = this.stories.filter(x => {
      return x.title.toLowerCase().includes(value)
    })
    this.p = 1;
  }

  clearSearch() {
    this.searchValues = '';
    this.filteredStories = this.stories;
  }
}

interface StoryList {
  id: number;
  title: string;
  url: string;
  by: string;
  time: string;
  score: number;
}

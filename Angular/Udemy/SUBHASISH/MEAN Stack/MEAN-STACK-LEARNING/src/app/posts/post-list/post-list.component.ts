import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Post } from '../post.model';
import { PostsService } from '../posts.service';
import { Subscription } from 'rxjs';
import { PageEvent } from '@angular/material/paginator';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css'],
})
export class PostListComponent implements OnInit, OnDestroy {
  userId!: string;
  private authStatusSub!: Subscription;
  userAuthenticated = false;
  posts: Post[] = [];
  private postSub: Subscription = new Subscription();
  isLoading: boolean = false;
  totalPost = 0;
  postPerPage = 5;
  currentPage = 1;
  pageSizeOptions = [5, 10, 15];
  constructor(
    private postService: PostsService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.isLoading = true;
    this.postService.getPosts(this.postPerPage, this.currentPage);
    this.userId = this.authService.getUserId();
    this.postSub = this.postService
      .getPostUpdateListener()
      .subscribe((postData: { posts: Post[]; postCount: number }) => {
        this.isLoading = false;
        this.posts = postData.posts;
        this.totalPost = postData.postCount;
      });
    this.userAuthenticated = this.authService.getIsUserAuthenticated();
    this.authStatusSub = this.authService
      .getAuthStatusListener()
      .subscribe((isUserAuthenticated) => {
        this.userAuthenticated = isUserAuthenticated;
        this.userId = this.authService.getUserId();
      });
  }
  ngOnDestroy() {
    this.postSub.unsubscribe();
    this.authStatusSub.unsubscribe();
  }

  onDelete(id: string) {
    this.isLoading = true;
    this.postService.deletePost(id).subscribe(() => {
      this.postService.getPosts(this.postPerPage, this.currentPage);
    });
  }

  onChangePage(pageData: PageEvent) {
    this.isLoading = true;
    this.currentPage = pageData.pageIndex + 1;
    this.postPerPage = pageData.pageSize;
    this.postService.getPosts(this.postPerPage, this.currentPage);
  }
}

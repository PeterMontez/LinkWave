export interface Post
{
    postId: number,
    title: string,
    content: string,
    picture: string,
    userId: number,
    forumId: number,
    forum: any,
    user: any
}
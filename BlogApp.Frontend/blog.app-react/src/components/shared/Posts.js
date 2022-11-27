import { useState, useEffect } from 'react'

//Components
import Post from './Post.js'

const Posts = () => {

    //Getting all posts from db and mapping them in post component
    const [posts, setPosts] = useState([]);
    useEffect(() => {
        async function getPosts() {
            const postsResult = await fetch('https://localhost:7222/api/Posts');
            setPosts(await postsResult.json());
        }
        getPosts();
    }, [])

    return (
        <>
            <div className='posts-container'>
                <h3>Posts</h3>
                <div id='posts-grid'>
                    {
                        posts && posts.map(post => (
                            <Post key={post.Id} post={post} />
                        ))
                    }
                </div>
            </div>
        </>
    )
}

export default Posts
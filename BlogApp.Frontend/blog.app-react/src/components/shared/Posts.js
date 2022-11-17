import { useState, useEffect } from 'react'

//Components
import Post from './Post.js'

const Posts = () => {

    const [posts, setPosts] = useState([]);
    useEffect(() => {
        async function getPosts() {
            const postsResult = await fetch('https://localhost:7222/api/Posts');
            setPosts(await postsResult.json());
            console.log(posts)
        }
        getPosts();
    }, [])
    console.log(posts)
    return (
        <>
            <div className='posts-container'>
                <h3>Posts</h3>
                <div id='posts-grid'>
                    {
                        posts && posts.map(post => (
                            <div >
                                <Post post={post} />
                            </div>
                        ))
                    }
                </div>
            </div>
        </>
    )
}

export default Posts
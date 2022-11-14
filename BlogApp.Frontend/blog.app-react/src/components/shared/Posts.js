import { useState, useEffect } from 'react'
import DOMPurify from 'dompurify';

//Components
import Post from './Post.js'

const Posts = () => {

    const [posts, setPosts] = useState([]);
    useEffect(() => {
        async function getPosts() {
            const postsResult = await fetch('');
            setPosts(await postsResult.json());
        }
        getPosts();
    }, []);

    return (
        <>
            <div className='posts-container'>
                <h3>Posts</h3>
                <div id='posts-grid'>
                    {
                        posts && posts.map(post => (
                            <div key={post.id}>
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
import React from 'react'
import DOMPurify from 'dompurify'

const Post = ({ post }) => {
    return (
        <>
            <div className='post'>
                <h4>{post.postTitle}</h4>
                <div className='post-image-body'>
                    <div className='image-container'>
                        <img src={post.imageUrl} alt="" />
                    </div>
                    <div className='post-body' dangerouslySetInnerHTML={{ __html: DOMPurify.sanitize(post.postBody) }}>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Post
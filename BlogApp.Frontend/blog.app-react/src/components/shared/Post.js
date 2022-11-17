import React from 'react'
import DOMPurify from 'dompurify'

const Post = ({ post }) => {

    function checkPost(post) {
        post.postTitle = DOMPurify.sanitize(post.postTitle)
        post.postBody = DOMPurify.sanitize(post.postBody)
        post.imageUrl = DOMPurify.sanitize(post.imageUrl)

        if (post.imageUrl === null || post.imageUrl.length === 0) {
            post.imageUrl = 'https://images.pexels.com/photos/163077/mario-yoschi-figures-funny-163077.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
        }
        return post;
    }
    checkPost(post)

    function setImage(post) {
        post.imageUrl = 'https://images.pexels.com/photos/163077/mario-yoschi-figures-funny-163077.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
    }
    return (
        <>
            <div className='post shadow'>
                <h4>{post.PostTitle}</h4>
                <div className='post-image-body'>
                    <div className='image-container'>
                        <img src={post.ImageUrl} onError={setImage(post)} alt='' />
                    </div>
                    <div className='post-body' dangerouslySetInnerHTML={{ __html: DOMPurify.sanitize(post.PostBody) }}>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Post
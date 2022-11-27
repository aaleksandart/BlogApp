import React from 'react'
import DOMPurify from 'dompurify'

const Post = ({ post }) => {

    //Sanitizing and validating post before display
    //Setting default image if image url is not ok
    function sanitizePost(post) {
        post.PostTitle = DOMPurify.sanitize(post.PostTitle)
        post.PostBody = DOMPurify.sanitize(post.PostBody)
        post.ImageUrl = DOMPurify.sanitize(post.ImageUrl)

        validatePost(post)
        return post;
    }

    function validatePost(post) {
        if (!/(https?:\/\/.*\.(?:png|jpg|jpeg))/i.test(post.ImageUrl)) {
            post.ImageUrl = 'https://images.pexels.com/photos/163077/mario-yoschi-figures-funny-163077.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
        }
        if (post.PostTitle === null || post.PostTitle === "") {
            post.PostTitle = "Post Title"
        }
        if (post.PostBody === null || post.PostBody === "") {
            post.PostBody = "Post Body"
        }
        return post
    }

    sanitizePost(post)

    return (
        <>
            <div className='post shadow'>
                <h4>{post.PostTitle}</h4>
                <div className='post-image-body'>
                    <div className='image-container'>
                        <img id='post-image' src={post.ImageUrl} alt='' />
                    </div>
                    <div className='post-body' dangerouslySetInnerHTML={{ __html: DOMPurify.sanitize(post.PostBody) }}>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Post
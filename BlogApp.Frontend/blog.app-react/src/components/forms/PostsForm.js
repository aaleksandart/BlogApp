import React from 'react'

const PostsForm = () => {
    return (
        <>
            <form>
                <div className='input-comp'>
                    <label htmlFor="">Post title</label>
                    <input className='shadow' type="text" />
                    {/* <span className='error-message'>Error</span> */}
                </div>
                <div className='input-comp'>
                    <label htmlFor="">Post</label>
                    <textarea className='shadow' type="text" />
                    {/* <span className='error-message'>Error</span> */}
                </div>
                <div className='input-comp'>
                    <label htmlFor="">Image URL</label>
                    <input className='shadow' type="text" />
                    {/* <span className='error-message'>Error</span> */}
                </div>
                <div className='shadow' id='error-messages'>
                    <p id='post-title-error' className='error-message'>You need a post title.</p>
                    <p id='post-error' className='error-message'>You need to fill in the post field.</p>
                    <p id='image-url-error' className='error-message'>You need a valid image url.</p>
                </div>
                <button className='shadow' id='submitPost'>Submit</button>
            </form>
        </>
    )
}

export default PostsForm
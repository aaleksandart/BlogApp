import DOMPurify from "dompurify";

export default function validateForm(values) {
    let errors = {};

    if (!values.postTitle) {
        errors.postTitle = "You need to fill in your post title."
    }

    if (!values.postBody) {
        errors.postBody = "You need a post."
    }

    if (!values.imageUrl) {
        errors.imageUrl = "You need to fill in your image URL."
    }

    return errors;
}